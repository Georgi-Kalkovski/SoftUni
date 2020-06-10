using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> collectionOfCards;

        public CardRepository()
        {
            this.collectionOfCards = new Dictionary<string, ICard>();
        }

        public int Count => this.collectionOfCards.Count;

        public IReadOnlyCollection<ICard> Cards => this.collectionOfCards.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card  cannot be null");
            }
            if (this.collectionOfCards.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card  {card.Name} already exists!");
            }
            this.collectionOfCards.Add(card.Name, card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            return this.collectionOfCards.Remove(card.Name);
        }

        public ICard Find(string name)
        {
            ICard cardFound = null;

            if (this.collectionOfCards.ContainsKey(name))
            {
                cardFound = this.collectionOfCards[name];
            }

            return cardFound;
        }
    }
}
