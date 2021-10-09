﻿using BattleCards.Data;
using BattleCards.Services;
using Microsoft.EntityFrameworkCore;
using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;
using System.Threading.Tasks;

namespace BattleCards
{
    class StartUp
    {
        public static async Task Main()
           => await HttpServer
               .WithRoutes(routes => routes
                   .MapStaticFiles()
                   .MapControllers())
               .WithServices(services => services
                   .Add<IViewEngine, CompilationViewEngine>()
                   .Add<IValidator, Validator>()
                   .Add<IPasswordHasher, PasswordHasher>()
                   .Add<BattleCardsDbContext>())
               .WithConfiguration<BattleCardsDbContext>(c => c.Database.Migrate())
               .Start();
    }
}