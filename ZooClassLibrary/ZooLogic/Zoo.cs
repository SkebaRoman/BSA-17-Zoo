using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public class Zoo
    {
        public delegate void ExitHandeler();
        public event ExitHandeler Exit; 

        private List<Animal> animals = new List<Animal>();
        private Random random = new Random();
        private Timer timer;

        public Zoo()
        {
            timer = new Timer(5000);
            timer.Elapsed += (sender, args) => TimerEvent(sender, args);
            timer.Start();
        }

        public IReadOnlyList<Animal> GetAnimals()
        {
            return animals;
        }

        private void TimerEvent(object sender, ElapsedEventArgs args)
        {
            TimeForChangeState();
        }

        private Animal GetAnimalByName(string name)
        {
            var animal = animals.Where(a => a.Name == name).FirstOrDefault();

            return animal != null ? animal : null;
        }
        public int GetAnimalLength()
        {
            return animals.Count;
        }
        public void AddAnimal(string name, string type)
        {
            var animal = GetAnimalByName(name);

            if (animal == null)
            {
                var returnedAnimal = AnimalAbstractFactory.GetType(name, type);

                if (returnedAnimal != null)
                {
                    animals.Add(returnedAnimal);
                    Console.WriteLine("Animal was added");
                }
                else
                {
                    throw new AnimalInvalidTypeException();
                }
            }
            else
            {
                throw new AnimalDuplicateNameException();
            }
        }
        public void RemoveAnimal(string name)
        {
            var animal = GetAnimalByName(name);

            if (animal != null)
            {
                if (animal.CurrentState == State.Dead)
                {
                    animals.Remove(animal);
                    Console.WriteLine("Animal was removed");
                }
                else
                {
                    throw new AnimalStillAliveException();
                }
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }
        public void FeedAnimal(string name)
        {
            var animal = GetAnimalByName(name);

            if (animal != null)
            {
                if (animal.CurrentState == State.Dead)
                {
                    throw new CanNotFeedDeadAnimalException();
                }
                else
                {
                    animal.Eat();
                    Console.WriteLine("Animal was fed");
                }
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }
        public void CureAnimal(string name)
        {
            var animal = GetAnimalByName(name);

            if (animal != null)
            {
                if (animal.CurrentState == State.Dead)
                {
                    throw new CanNotCureDeadAnimalException();
                }
                else
                {
                    animal.Cure();
                    Console.WriteLine("Animal was cured");
                }
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }

        public void ShowAllAnimals()
        {
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public string AboutAnimal(string name)
        {
            var animal = GetAnimalByName(name);

            if (animal != null)
            {
                return animal.ToString();
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }
        private int GetRandomAnimalIndex()
        {
            return random.Next(0, animals.Count);
        }
        public void TimeForChangeState()
        {
            if (animals.Count >= 2)
            {
                if (!AreAllDead())
                {
                    animals[GetRandomAnimalIndex()].ChangeState();
                }
                else
                {
                    Exit?.Invoke();
                }
            }
        }
        private bool AreAllDead()
        {
            foreach (var item in animals)
            {
                if (item.CurrentState != State.Dead)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
