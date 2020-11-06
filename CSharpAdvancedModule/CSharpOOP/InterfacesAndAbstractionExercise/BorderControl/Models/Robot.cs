using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Robot : ICheck
    {
        public Robot(string modelName, string id)
        {
            Name = modelName;
            Id = id;
        }

        public string Name { get;  private set; }
        public string Id { get; private set; }


       
    }
}
