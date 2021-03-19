using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using System;

namespace RealEstates.Application
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
