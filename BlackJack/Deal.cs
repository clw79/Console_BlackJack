using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deal
    {
        public void DealCard(List<CardModel>Deck, List<CardModel> Hand)
        {
            //Creates a new instance of random.
            var random = new Random();
            //Takes a random position in the list
            int drawCard = random.Next(Deck.Count);
            //Adds the card in the selected position to the DealerHand.
            Hand.Add(Deck[drawCard]);
            

            //Removes the selected card from the deck.
            Deck.Remove(Deck[drawCard]);
            //Resizes the capacity of the list.
            Deck.TrimExcess();
        }
    }
}
