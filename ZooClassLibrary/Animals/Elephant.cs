using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public class Elephant : Animal
    {
        public override int CurrentHealth { get; set; } = 7;
        public override int MaxHealth { get; protected set; } = 7;
        public override string Name { get; set; }
        public override State CurrentState { get; set; } = State.Sated;
        public Elephant(string name) : base(name) { }
        public override void Eat()
        {
            CurrentState = State.Sated;
        }
        public override void Cure()
        {
            if (CurrentHealth + 1 <= MaxHealth)
            {
                CurrentHealth += 1;
            }
            else
            {
                throw new AnimalMaxHealthException();
            }
        }
        public override void ChangeState()
        {
            if (CurrentState == State.Sick)
            {
                if (CurrentHealth - 1 > 0)
                {
                    CurrentHealth -= 1;
                }
                else
                {
                    CurrentState = State.Dead;
                }
            }
            else if (CurrentState != State.Dead)
            {
                CurrentState -= 1;
            }
        }
        public override string ToString()
        {
            return string.Format("This is Elephant called: " + Name + ", with state: " + CurrentState + " and health: " + CurrentHealth);
        }
    }
}
