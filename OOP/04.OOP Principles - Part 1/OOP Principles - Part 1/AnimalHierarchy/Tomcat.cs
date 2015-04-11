namespace AnimalHierarchy
{
    public class Tomcat : Cat
    {
        public Tomcat(int inputAge, string inputName)
            : base(inputAge, inputName)
        {
            this.Sex = Sex.Male;
        }

        public override string ProduceSound()
        {
            return "FEED ME HUMAN!";
        }
    }
}
