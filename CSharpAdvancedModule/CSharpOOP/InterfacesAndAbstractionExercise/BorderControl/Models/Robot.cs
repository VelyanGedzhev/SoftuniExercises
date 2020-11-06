using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IAddable
    {
        public Robot(string modelName, string id)
        {
            ModelName = modelName;
            Id = id;
        }

        public string ModelName { get; set; }
        public string Id { get; private set; }


       
    }
}
