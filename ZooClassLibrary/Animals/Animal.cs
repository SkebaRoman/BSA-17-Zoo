namespace ZooClassLibrary
{
    public enum State { Dead, Sick, Hungry, Sated }

    public abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract int CurrentHealth { get; set; }
        public abstract int MaxHealth { get; protected set; }
        public abstract State CurrentState { get; set; }
        public Animal(string name)
        {
            Name = name;
        }
        public abstract void Eat();
        public abstract void Cure();
        public abstract void ChangeState();
        public abstract override string ToString();
    }
}
