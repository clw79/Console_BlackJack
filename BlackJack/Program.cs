using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack
{


    public class Program
    {
        public static void Main(string[] args)
        {
            string playGame = "y";
            while (!(playGame == "n"))
            {
                Console.Clear();

                PointCalculations pointCalculations = new PointCalculations();
                int playerHandPoints = 0;
                int dealerHandPoints = 0;
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
                Deal deal = new Deal();
                for (int i = 0; i < 2; i++)
                {
                    deal.DealCard(DeckofCards, PlayerHand);
                    deal.DealCard(DeckofCards, DealerHand);
                }

                playerHandPoints = pointCalculations.PointTotal(PlayerHand);
                dealerHandPoints = pointCalculations.PointTotal(DealerHand);

                Console.WriteLine("--Dealer Hand--");
                Console.WriteLine("{0} of {1}\n", DealerHand[1].Number, DealerHand[1].Suit);

                Console.WriteLine("--Player Hand--");
                PointCalculations.Display(PlayerHand);
                Console.WriteLine("{0} Total Points\n", playerHandPoints);

                Console.WriteLine("   Press y and enter to receive next card, any other key to pass.");
                string newCard = Console.ReadLine();


                while (newCard == "y" && playerHandPoints < 22)
                {

                    Console.WriteLine("--Player Hand--");
                    //Calls a method that removes a card from the deck and inserts it in the players hand.
                    deal.DealCard(DeckofCards, PlayerHand);
                    playerHandPoints = pointCalculations.AceCheck(PlayerHand);
                    PointCalculations.Display(PlayerHand);
                    newCard = pointCalculations.IfBusted(playerHandPoints);
                }
                Console.WriteLine();

                Console.WriteLine("--DealerHand Cards--");

                PointCalculations.Display(DealerHand);
                Console.WriteLine("   Points = {0}\n", dealerHandPoints);
                Console.ReadKey();

                int ifAce = pointCalculations.DealerSoft17(DealerHand, dealerHandPoints);

                while (dealerHandPoints < 17 || ifAce == 1)
                {

                    deal.DealCard(DeckofCards, DealerHand);
                    dealerHandPoints = pointCalculations.AceCheck(DealerHand);
                    Console.WriteLine("--DealerHand Cards--");
                    PointCalculations.Display(DealerHand);
                    Console.WriteLine("   Points = {0}\n", dealerHandPoints);
                    ifAce = pointCalculations.DealerSoft17(DealerHand, dealerHandPoints);
                    Console.ReadKey();
                }

                Console.WriteLine("Dealer has {0} points,  Player has {1} points.\n", dealerHandPoints, playerHandPoints);

                PointCalculations.WinorLoose(dealerHandPoints, playerHandPoints);

                Console.WriteLine();

                Console.WriteLine("   Press n and enter to exit, any other key to play again.");
                playGame = Console.ReadLine();

            }

        }

        
    }
}
