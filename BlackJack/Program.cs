using System;
using System.Collections.Generic;


namespace BlackJack
{


    public class Program
    {
        public static void Main(string[] args)
        {
            //Sets the initial state for the while statement to y so that the loop will run.
            string playGame = "y";
            //Checks to see if the status of playGame has changed.
            while (!(playGame == "n"))
            {
                //Clears console from for next game.
                Console.Clear();

                //Allowes the PointTotal function to run.
                PointCalculations pointCalculations = new PointCalculations();
                //Variables that will hold the point totals for player and dealer.
                int playerHandPoints = 0;
                int dealerHandPoints = 0;
                //Creates a list to hold the deck of cards.
                List<CardModel> DeckofCards = new List<CardModel>();
                //Calls a method that creates the deck and adds it to the list.
                CardDeck cardDeck = new CardDeck();
                cardDeck.CreateDeck(DeckofCards);

                //Creates a list to hold the players and dealers cards.
                List<CardModel> PlayerHand = new List<CardModel>();
                List<CardModel> DealerHand = new List<CardModel>();
                //Calls a method thats deals two cards to the player and dealer and adding them
                //to the player's and dealer's hand list. 
                Deal deal = new Deal();
                for (int i = 0; i < 2; i++)
                {
                    deal.DealCard(DeckofCards, PlayerHand);
                    deal.DealCard(DeckofCards, DealerHand);
                }
                //Calculates the total points of the player and dealer hands.
                playerHandPoints = pointCalculations.PointTotal(PlayerHand);
                dealerHandPoints = pointCalculations.PointTotal(DealerHand);

                //Displays the header and the card showing for the dealer.  Hidden card has been delt but is not
                //shown till after the players turn.
                Console.WriteLine("--Dealer Hand--");
                Console.WriteLine("{0} of {1}\n", DealerHand[1].Number, DealerHand[1].Suit);
                //Displays header on console.
                Console.WriteLine("--Player Hand--");
                //Calls method that runs a loop to display each card's Number, Suit and PointValue from the list.
                PointCalculations.Display(PlayerHand);
                //Displays the point total for player.
                Console.WriteLine("{0} Total Points\n", playerHandPoints);

                //Give the player the option to receive another card or to stand.
                Console.WriteLine("   Press y to receive next card, any other key to pass.");
                //Varaible holding status of card being requested.
                string newCard = "n";
                //User input for a new card
                char getCard = Console.ReadKey(true).KeyChar;
                //Checks if the user typed a y or Y
                if ((getCard == 'Y') || (getCard == 'y'))
                {
                    newCard = "y";
                }
                //Checks to see if user requested card and that they have not yet busted.
                while (newCard == "y" && playerHandPoints < 22)
                {
                    //Displays header.
                    Console.WriteLine("--Player Hand--");
                    //Calls a method that removes a card from the deck and inserts it in the players hand.
                    deal.DealCard(DeckofCards, PlayerHand);
                    playerHandPoints = pointCalculations.PointTotal(PlayerHand);
                    //Checking to see if the busted hand has an Ace with the value of eleven.  If so it changes it to
                    // a value of one and recalculates the player points.
                    if (playerHandPoints > 21)
                    {
                        foreach (CardModel card in PlayerHand)
                        {
                            if (card.PointValue == 11)
                            {
                                card.PointValue = 1;
                                break;
                            }
                        }
                        playerHandPoints = pointCalculations.PointTotal(PlayerHand);
                    }
                    //Calls method that runs a loop to display each card's Number, Suit and PointValue from the list.
                    PointCalculations.Display(PlayerHand);
                    //Checks to see if player busted and if so ends their turn.
                    if (playerHandPoints > 21)
                    {
                        Console.WriteLine("   You Busted, You have {0} points.", playerHandPoints);
                        newCard = "n";
                    }
                    //If not busted, displays player's points and asks user if the want another card.
                    else
                    {
                        Console.WriteLine("   Points = {0}", playerHandPoints);
                        Console.WriteLine();
                        Console.WriteLine("   Press y to receive next card, any other key to pass.");
                        
                        //User input for a new card
                        getCard = Console.ReadKey(true).KeyChar;
                        //Checks if the user typed a y or Y
                        if ((getCard == 'Y') || (getCard == 'y'))
                        {
                            newCard = "y";
                        }
                        else
                        {
                            newCard = "n";
                        }
                    }
                }
                Console.WriteLine();
                //Displays header.
                Console.WriteLine("--DealerHand Cards--");
                //Calls method that runs a loop to display each card's Number, Suit and PointValue from the list.
                PointCalculations.Display(DealerHand);
                //Displays the point total for dealer.
                Console.WriteLine("   Points = {0}\n", dealerHandPoints);
                //Waits for user to view dealer action.
                Console.ReadKey();

                //Sets initial bool value to false for a check for an ace.
                bool ifAce = false;
                //Checks to see if dealer hand has a soft 17 that would require the dealer to take another card.
                if (dealerHandPoints == 17)
                {
                    //Checks the dealers hand for an Ace that is still showing a eleven value and if found changes
                    //bool value.
                    foreach (CardModel card in DealerHand)
                    {
                        if (card.PointValue == 11)
                        {
                            ifAce = true;
                        }
                    }
                }
                //Checks the dealer hand for a value less than 17 or if it is a soft 17.
                while (dealerHandPoints < 17 || ifAce == true)
                {
                    //Calls a method that removes a card from the deck and inserts it in the dealer's hand.
                    deal.DealCard(DeckofCards, DealerHand);
                    //Updating the dealers total points
                    dealerHandPoints = pointCalculations.PointTotal(DealerHand);

                    //Checking to see if the busted hand has an Ace with the value of eleven.  If so it changes it to
                    // a value of one and recalculates the dealer points.
                    if (playerHandPoints > 21)
                    {
                        foreach (CardModel card in PlayerHand)
                        {
                            if (card.PointValue == 11)
                            {
                                card.PointValue = 1;
                                break;
                            }
                        }
                        playerHandPoints = pointCalculations.PointTotal(PlayerHand);
                    }
                    //Displays header.
                    Console.WriteLine("--DealerHand Cards--");
                    //Calls method that runs a loop to display each card's Number, Suit and PointValue from the list.
                    PointCalculations.Display(DealerHand);
                    //Displays the point total for dealer.
                    Console.WriteLine("   Points = {0}\n", dealerHandPoints);
                    //Checks to see if dealer hand has a soft 17 that would require the dealer to take another card.
                    if (dealerHandPoints == 17)
                    {
                        //Checks the dealers hand for an Ace that is still showing a eleven value and if found changes
                        //bool value.
                        foreach (CardModel card in DealerHand)
                        {
                            if (card.PointValue == 11)
                            {
                                ifAce = true;
                            }
                            //If the hand does not contain an Ace and shows 17, it breaks the while loop by changing
                            //bool value to false,
                            else
                            {
                                ifAce = false;
                            }
                        }
                    }
                    //Waits for user to view dealer action.
                    Console.ReadKey();
                }
                //Displays final points for the dealer and player.
                Console.WriteLine("Dealer has {0} points,  Player has {1} points.\n", dealerHandPoints, playerHandPoints);
                //Cheshing different conditions to see who one.
                //Player busted, Dealer wins.
                if (playerHandPoints > 21)
                {
                    Console.WriteLine("   You Lost because You Busted");
                }
                //Dealer busted, Player wins
                else if (dealerHandPoints > 21)
                {
                    Console.WriteLine("   Dealer Busted, You Win!!!");
                }
                //Player points and more than Dealers points, Player wins.
                else if (dealerHandPoints < playerHandPoints)
                {
                    Console.WriteLine("   You Win!!!!!");
                }
                //Dealer and Player have equal points, both sides tie.
                else if (dealerHandPoints == playerHandPoints)
                {
                    Console.WriteLine("   You Pushed");
                }
                //Dealer points are more than Player, Dealer wins.
                else
                {
                    Console.WriteLine("   You Lost");
                }

                Console.WriteLine();
                //Asks user to play again.
                Console.WriteLine("   Press Q to quit, any other key to play again.");
                //User input for a new card
                char quit = Console.ReadKey(true).KeyChar;
                //Checks if the user typed a q or Q
                if ((quit == 'Q') || (quit == 'q'))
                {
                    playGame = "n";
                }
                else
                {
                    playGame = "y";
                }

            }

        }


    }
}
