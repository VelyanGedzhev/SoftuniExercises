using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Data;
using Quiz.Services;
using System;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var quizService = serviceProvider.GetService<IUserAnswerService>();
            //quizService.Add("C# DB");

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("1+1", 1);

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("2", 5, true, 2);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            var userId = "79443e63-7837-4968-abf4-29650fae9c37";
            //userAnswerService.AddUserAnswer(userId, 1, 2, 1);

            //var quiz = quizService.GetQuizById(1);

            //Console.WriteLine(quiz.Title);
            //foreach (var question in quiz.Questions)
            //{
            //    Console.WriteLine(question.Title);

            //    foreach (var answer in question.Answers)
            //    {
            //        Console.WriteLine($"--{answer.Title}");
            //    }
            //}

            var quiz = quizService.GetUserResult(userId, 1);
            Console.WriteLine(quiz);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
        }
    }
}
