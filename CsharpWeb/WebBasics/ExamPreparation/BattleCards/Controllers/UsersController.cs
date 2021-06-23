using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Users;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly BattleCardsDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            BattleCardsDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher.HashPassword(model.Password);

            var userId = this.data
                .Users
                .Where(
                    u => u.Username == model.Username
                    && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Error("Username and password combination is not valid.");
            }

            this.SignIn(userId);

            return Redirect("/Cards/All");
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"{model.Username} is occupied.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"{model.Email} is occupied.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = this.passwordHasher.HashPassword(model.Password),
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
