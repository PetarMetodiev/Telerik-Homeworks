namespace AnimalHierarchy
{
    public class Kitten : Cat
    {
        public Kitten(int inputAge, string inputName)
            : base(inputAge, inputName)
        {
            this.Sex = Sex.Female;
        }
        public override string ProduceSound()
        {
            return "YOU ARE DOOMED!";
        }
    }
}
