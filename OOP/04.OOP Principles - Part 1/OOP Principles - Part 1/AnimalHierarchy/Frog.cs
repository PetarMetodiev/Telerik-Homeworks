namespace AnimalHierarchy
{
    using System.Linq;

    public class Frog:Animal
    {
        public Frog(int inputAge, string inputName, Sex inputSex)
            : base(inputAge, inputName)
        {
            this.Sex = inputSex;
        }

        public override string ProduceSound()
        {
            return "Kvak!";
        }
    }
}
