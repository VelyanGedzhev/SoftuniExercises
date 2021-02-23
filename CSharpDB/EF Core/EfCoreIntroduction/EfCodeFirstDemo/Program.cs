using EfCodeFirstDemo.Models;
using System;

namespace EfCodeFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DemoDBContext();

            //Better way is to use Migrations
            db.Database.EnsureCreated();
        }
    }
}
