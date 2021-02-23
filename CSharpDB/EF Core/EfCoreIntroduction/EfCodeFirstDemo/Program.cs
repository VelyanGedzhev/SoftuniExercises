using EfCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfCodeFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DemoDBContext();

            //db.Database.EnsureCreated();
            //Better way is to use Migrations
            db.Database.Migrate();
        }
    }
}
