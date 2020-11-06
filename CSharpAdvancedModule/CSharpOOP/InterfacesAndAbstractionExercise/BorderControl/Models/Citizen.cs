using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IAddable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }

        
    }
}
