using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IBirthday, IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }
        public string Birthday { get; private set; }

        public int Food { get; private set; }

        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
