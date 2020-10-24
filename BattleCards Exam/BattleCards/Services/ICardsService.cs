using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        //Cards/Add (от условието)
        int AddCard(AddCardInputModel input);

        // Cards/Collection (от условието)
        IEnumerable<CardViewModel> GetAll();

        // Помощен метод, който ще ни трябва за другите методи
        IEnumerable<CardViewModel> GetByUserId(string userId);

        // Cards/AddToCollection?cardId={cardId} (logged-in user) - от условието
        void AddCardToUserCollection(string userId, int cardId);

        // Cards/RemoveFromCollection?cardId={cardId} (logged-in user) - от уловиетое
        void RemoveCardFromUserCollection(string userId, int cardId);
    }
}
