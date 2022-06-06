using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class InitialDeal
    {
        public int initialDealerHandPoints = 0;
        public int initialPlayerHandPoints = 0;
        public void Deal(List<CardModel> CardDeck, List<CardModel> PlayerDeal, List<CardModel> DealerDeal)
        {
            //Creates a new instance of random.
            var random = new Random();


            //Gives two cards to DealerHand and PlayerHand.
            for (int i = 0; i < 2; i++)
            {
                //Takes a random position in the list
                int index = random.Next(CardDeck.Count);
                //Adds the card in the selected position to the PlayerHand.
                PlayerDeal.Add(CardDeck[index]);
                //Add the points for the player.
                initialPlayerHandPoints += CardDeck[index].cardPointValue;
                //Removes the selected card from the deck.
                CardDeck.Remove(CardDeck[index]);
                //Resizes the capacity of the list.
                CardDeck.TrimExcess();

                //Takes a random position in the list
                int index2 = random.Next(CardDeck.Count);
                //Adds the card in the selected position to the DealerHand.
                DealerDeal.Add(CardDeck[index2]);
                //Add the points for the dealer.
                initialDealerHandPoints += CardDeck[index2].cardPointValue;
                //Removes the selected card from the deck.
                CardDeck.Remove(CardDeck[index2]);
                //Resizes the capacity of the list.
                CardDeck.TrimExcess();
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("--DealerHand Cards--");
            //Prints Dealers face down card
            Console.WriteLine("This card is face down {0} of {1}.", DealerDeal[0].cardNumber, DealerDeal[0].cardSuit);
            Console.WriteLine();
            //Prints Dealers showing card
            Console.WriteLine("{0} of {1}\n", DealerDeal[1].cardNumber, DealerDeal[1].cardSuit);
            //Prints PlayerHand
            Console.WriteLine("--PlayerHand Cards--");
            foreach (CardModel card in PlayerDeal)
            {
                Console.WriteLine("{0} of {1}", card.cardNumber, card.cardSuit);
            }
            Console.WriteLine("   Points = {0}", initialPlayerHandPoints);
            Console.WriteLine();
            //Verifies number of cards left in deck.
            Console.WriteLine("The card deck has {0} cards,", CardDeck.Count);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        }
    }
}

