using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        // GET /cards/add
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel cardInput)
        {

            if (string.IsNullOrEmpty(cardInput.Name) || cardInput.Name.Length < 5 || cardInput.Name.Length > 15)
            {
                return this.Error("Name should be between 5 and 15 characters long.");
            }

            if (string.IsNullOrWhiteSpace(cardInput.Image))
            {
                return this.Error("The image is required!");
            }

            if (!Uri.TryCreate(cardInput.Image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid.");
            }

            if (string.IsNullOrWhiteSpace(cardInput.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (cardInput.Attack < 0)
            {
                return this.Error("Attack should be non-negative integer.");
            }

            if (cardInput.Health < 0)
            {
                return this.Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(cardInput.Description) || cardInput.Description.Length > 200)
            {
                return this.Error("Description is required and its length should be at most 200 characters.");
            }

            var cardId = this.cardsService.AddCard(cardInput);

            //var userId = this.GetUserId();
            
            //this.cardsService.AddCardToUserCollection(userId, cardId);
            
            return this.Redirect("/Cards/All");
        }

        // /cards/all
        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var cardsViewModel = this.cardsService.GetAll();
            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            return this.View();

        }

        public HttpResponse AddToCollection(int cardId)
        {
            return this.View();

        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            return this.View();
        }
    }
}