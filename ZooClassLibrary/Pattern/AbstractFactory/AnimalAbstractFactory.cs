using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public static class AnimalAbstractFactory
    {
        public static Animal GetType(string name, string type)
        {
            switch (type.ToLower())
            {
                case "bear":
                    return new Bear(name);
                case "elephant":
                    return new Elephant(name);
                case "fox":
                    return new Fox(name);
                case "lion":
                    return new Lion(name);
                case "tiger":
                    return new Tiger(name);
                case "wolf":
                    return new Wolf(name);
                default:
                    throw new AnimalInvalidTypeException();
            }
        }
    }
}
