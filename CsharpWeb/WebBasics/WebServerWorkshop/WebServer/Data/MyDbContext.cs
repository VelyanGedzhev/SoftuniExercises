using System.Collections.Generic;
using WebServer.Data.Models;

namespace WebServer.Data
{
    public class MyDbContext : IDataContext
    {
        public MyDbContext()
            => this.Cats = new List<Cat>
            {
                new Cat{Id = 1, Name = "Vancho", Age = 3},
                new Cat{Id = 2, Name = "Petko", Age = 7},
                new Cat{Id = 3, Name = "PussInBoots", Age = 5 },
            };

        public IEnumerable<Cat> Cats { get; }
    }
}
