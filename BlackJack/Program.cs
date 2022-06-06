using System;
using System.Collections.Generic;

namespace BlackJack
{


    public class Program
    {
        

        public static void Main(string[] args)
        {
            //Creates a list to hold the deck of cards.
            List<CardModel> DeckofCards = new List<CardModel>();
            //Calls a method that creates the deck and adds it to the list.
            CardDeck cardDeck = new CardDeck();
            cardDeck.CreateDeck(DeckofCards);

            //Creates a list to hold the players and bealers cards.
            List<CardModel> PlayerHand = new List<CardModel>();
            List<CardModel> DealerHand = new List<CardModel>();
            //Calls a method thats deals two cards to the player and dealer by adding them
            //to the player's and dealer's hand list. 
            InitialDeal initialDeal = new InitialDeal();
            initialDeal.Deal(DeckofCards, PlayerHand, DealerHand);

            //Creates a variable to hold the point value that had been established in the initial deal.
            int playerHandPoints = initialDeal.initialPlayerHandPoints;
            int dealerHandPoints = initialDeal.initialDealerHandPoints;

            Console.WriteLine("   Press y and enter to receive next card, any other key to pass.");
            string newCard = Console.ReadLine();

            while (newCard == "y" && playerHandPoints <22)
            {
                //Calls a method that removes a card from the deck and inserts it in the players hand.
                AdditionalCard additionalCard = new AdditionalCard();
                playerHandPoints += additionalCard.NextCard(DeckofCards, PlayerHand);

                Console.WriteLine("--PlayerHand Cards--");
                foreach (CardModel card in PlayerHand)
                {
                    Console.WriteLine("{0} of {1}, {2} points", card.cardNumber, card.cardSuit, card.cardPointValue);
                }

                PointCalculations pointCalculations = new PointCalculations();
                newCard = pointCalculations.IfBust(playerHandPoints);

                
            }
            Console.WriteLine();
            Console.WriteLine("--DealerHand Cards--");
            foreach (CardModel card in DealerHand)
            {
                Console.WriteLine("{0} of {1}, {2} points", card.cardNumber, card.cardSuit, card.cardPointValue);
            }
            Console.WriteLine("   Points = {0}\n", dealerHandPoints);
            Console.ReadKey();

            while (dealerHandPoints < 17)
            {
                //Calls a method that removes a card from the deck and inserts it in the dealers hand.
                AdditionalCard additionalCard = new AdditionalCard();
                dealerHandPoints += additionalCard.NextCard(DeckofCards, DealerHand);

                Console.WriteLine("--DealerHand Cards--");
                foreach (CardModel card in DealerHand)
                {
                    Console.WriteLine("{0} of {1}, {2} points", card.cardNumber, card.cardSuit, card.cardPointValue);
                }
                Console.WriteLine("   Points = {0}\n", dealerHandPoints);
                Console.ReadKey();
            }

            Console.WriteLine("Dealer has {0} points,  Player has {1} points.\n", dealerHandPoints, playerHandPoints);

            PointCalculations.WinorLoose(dealerHandPoints, playerHandPoints);
        }
    }
}
