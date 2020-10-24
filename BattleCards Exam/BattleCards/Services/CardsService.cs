using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCard(AddCardInputModel input)
        {
            var card = new Card
            {
                Name = input.Name,
                ImageUrl = input.Image,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description
                
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();

            return card.Id;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            throw new NotImplementedException();
        }
    }
}
