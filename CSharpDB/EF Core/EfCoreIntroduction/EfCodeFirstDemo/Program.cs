using EfCodeFirstDemo.Models;
using System;

namespace EfCodeFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DemoDBContext();
            db.Database.EnsureCreated();
        }
    }
}
