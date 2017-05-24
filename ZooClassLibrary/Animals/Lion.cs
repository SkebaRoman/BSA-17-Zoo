using ZooClassLibrary.UserException;

namespace ZooClassLibrary
{
    public class Lion : Animal
    {
        public override int CurrentHealth { get; set; } = 5;
        public override int MaxHealth { get; protected set; } = 5;
        public override string Name { get; set; }
        public override State CurrentState { get; set; } = State.Sated;
        public Lion(string name) : base(name) { }
        public override string ToString()
        {
            return string.Format("This is Lion called: " + Name + ", with state: " + CurrentState + " and health: " + CurrentHealth);
        }
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
                    CurrentHealth -= 1;
                    CurrentState = State.Dead;
                }
            }
            else if (CurrentState != State.Dead)
            {
                CurrentState -= 1;
            }
        }
    }
}
