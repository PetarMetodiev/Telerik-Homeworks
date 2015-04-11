using System.Text;
namespace PersonClass
{
    public class Person
    {
        public string Name { get; set; }
        public uint? Age { get; set; }

        public override string ToString()
        {
            StringBuilder personInfo = new StringBuilder();

            personInfo.AppendLine("Name: " + this.Name);
            personInfo.Append("Age: ");

            // I know the short variant, but to me it looks unclear and I prefer using if else statements.
            if (this.Age == null)
            {
                personInfo.AppendLine("Not specified.");
            }
            else
            {
                personInfo.AppendLine("" + this.Age);
            }

            return personInfo.ToString();
        }
    }
}
