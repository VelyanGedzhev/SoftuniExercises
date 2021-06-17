using System.Collections.Generic;
using WebServer.Data.Models;

namespace WebServer.Data
{
    public interface IDataContext
    {
        IEnumerable<Cat> Cats { get; }
    }
}
