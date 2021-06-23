using BattleCards.Data;
using BattleCards.Data.Models;
using BattleCards.Models.Cards;
using BattleCards.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly BattleCardsDbContext data;

        public CardsController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            BattleCardsDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.data
                .Cards
                .Select(c => new CardsListingViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = c.ImageUrl,
                    Keyword = c.Keyword,
                    Description = c.Description,
                    Attack = c.Attack,
                    Health = c.Health
                })
                .ToList();

            return View(cards);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCardFormModel model)
        {
            var modelErrors = this.validator.ValidateCard(model);

            if (this.data.Cards.Any(n => n.Name == model.Name))
            {
                modelErrors.Add($"Card with name '{model.Name}' already exists.");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var card = new Card
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description
            };

            this.data.Cards.Add(card);
            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            bool isInCollection = this.data.UserCards.Any(c => c.CardId == cardId && c.UserId == this.User.Id);

            if (isInCollection)
            {
                return Error("Card already in your collection.");
            }

            var userCard = new UserCard
            {
                CardId = cardId,
                UserId = this.User.Id
            };

            this.data.UserCards.Add(userCard);
            this.data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var cards = this.data
                .UserCards
                .Where(u => u.UserId == this.User.Id)
                .Select(c => new CardsListingViewModel
                {
                    Id = c.Card.Id,
                    Name = c.Card.Name,
                    Description = c.Card.Description,
                    Image = c.Card.ImageUrl,
                    Keyword = c.Card.Keyword,
                    Attack = c.Card.Attack,
                    Health = c.Card.Health
                })
                .ToList();


            return View(cards);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        {
            var userCard = this.data.UserCards.FirstOrDefault(c => c.CardId == cardId && c.UserId == this.User.Id);

            if (userCard == null)
            {
                return Error("Card not in your collection.");
            }

            this.data.UserCards.Remove(userCard);
            this.data.SaveChanges();

            return Redirect("/Cards/Collection");
        }
    }
}
