namespace AnimalHierarchy
{
    using System.Linq;
    public class Dog : Animal
    {
        public Dog(int inputAge, string inputName, Sex inputSex)
            : base(inputAge, inputName)
        {
            this.Sex = inputSex;
        }

        public override string ProduceSound()
        {
            return "Bark!";
        }
    }
}
