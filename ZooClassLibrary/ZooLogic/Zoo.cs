using System;
using System.Collections.Generic;
using System.Linq;
using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        private Random random = new Random();

        public Zoo()
        {
            MyTimer.MyTimer timer = new MyTimer.MyTimer(this);
            timer.TimerStart();
        }

        private Animal GetAnimalByName(string name)
        {
            var animal = animals.Where(a=>a.Name == name).FirstOrDefault();

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
                animal.Eat();
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
                animal.Cure();
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }

        public void ShowAllAnimals()
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
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
                    Environment.Exit(0);
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
