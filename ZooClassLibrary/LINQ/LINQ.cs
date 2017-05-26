using System;
using System.Linq;
using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public class LINQ
    {
        private Zoo zoo;

        public LINQ(Zoo zoo)
        {
            this.zoo = zoo;
        }
        private bool isEmpty(int count)
        {
            if (count > 0)
            {
                return true;
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }
        //Показать всех животных, сгруппированных по виду животного
        public void ShowAnimalsGroupByType()
        {
            var animals = zoo.GetAnimals().GroupBy(x => x.GetType().Name).Select(x => new { Animals = x.ToList() });

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.Animals.FirstOrDefault().ToString());
                }
            }
        }
        //Показать животных по состоянию - в параметрах передать Состояние
        public void ShowAnimalByState(State state)
        {
            var animals = zoo.GetAnimals().Where(x => x.CurrentState == state);

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }
        //Показать всех тигров, которые больны
        public void ShowAllSickTigers()
        {
            var animals = zoo.GetAnimals().Where(x => x.GetType().Name == "Tiger" && x.CurrentState == State.Sick);

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }
        //Показать слона с определенной кличкой, которая задается в параметре
        public void ShowElephantByName(string name)
        {
            var elephant = zoo.GetAnimals().Where(x => x.GetType().Name == "Elephant" && x.Name == name).FirstOrDefault();

            if (elephant != null)
            {
                Console.WriteLine(elephant.ToString());
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }
        //Показать список всех кличек животных, которые голодны
        public void ShowAllNamesHungryAnimals()
        {
            var animals = zoo.GetAnimals().Select(x => new { Animal = x }).Where(x => x.Animal.CurrentState == State.Hungry);

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.Animal.Name + " is hungry");
                }
            }
        }
        //Показать самых здоровых животных каждого вида (по одному на каждый вид)
        public void ShowMostHealthAnimalByType()
        {
            var animals = zoo.GetAnimals().Where(x => x.CurrentHealth == x.MaxHealth).GroupBy(x => x.GetType().Name);

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.FirstOrDefault().ToString());
                }
            }
        }
        //Показать количество мертвых животных каждого вида
        public void ShowDeadAnimalCountByType()
        {
            var animals = zoo.GetAnimals().GroupBy(x => x.GetType().Name)
                .Select(x => new { type = x.FirstOrDefault().GetType().Name, count = x.Where(z => z.CurrentState == State.Dead).Count() });

            if (isEmpty(animals.Count()))
            {
                foreach (var item in animals)
                {
                    Console.WriteLine(item.type + ": " + item.count);
                }
            }
        }
        //Показать всех волков и медведей, у которых здоровье выше 3
        public void ShowWolfAndBearByHealth()
        {
            var animals = zoo.GetAnimals().Where(x => x.GetType().Name == "Wolf" || x.GetType().Name == "Bear")
                .Where(x => x.CurrentHealth >= 3);

            if (isEmpty(animals.Count()))
            {
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }
        //Показать животное с максимальным здоровьем и животное с минимальным здоровьем (описать одним выражением)
        public void ShowMinAndMaxHeathAnimal()
        {
            //i done trick, like this, if it is good, i'm happy :D
            var item = zoo.GetAnimals().OrderBy(x => x.CurrentHealth).ToList();

            if (isEmpty(item.Count()))
            {
                Console.WriteLine("Min health: " + item.First().CurrentHealth + " Max health: " + item.Last().CurrentHealth);
            }
        }
        //Показать средней количество здоровья у животных в зоопарке
        public void ShowAverageAnimalHeath()
        {
            var animals = zoo.GetAnimals();

            if (isEmpty(animals.Count()))
            {
                Console.WriteLine("Average: " + zoo.GetAnimals().Average(x => x.CurrentHealth));
            }
        }
    }
}