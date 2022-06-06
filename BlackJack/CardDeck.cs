using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class CardDeck : Program
    {
        //private List<CardModel> DeckCreator = new List<CardModel>();
        //THis list will act as the players hand holding the cards in play.
        //private List<CardModel> PlayerHandCreator = new List<CardModel>();
        //This list will act as the dealers hand holding the cards in play.
        //private List<CardModel> DealerHandCreator = new List<CardModel>();
        //Creating the variables that will hole the  points for each player.


        public void CreateDeck(List<CardModel> DeckCreation)
        {
            //This loop first loop that cycles through the different suits.
            for (int i = 0; i < 4; i++)
            {
                int suit = i;
                // Loops through each card that is in each suit.
                for (int j = 2; j < 15; j++)
                {
                    int value = j;

                    //Creats a single card that properties can be applied to.
                    CardModel card = new CardModel();

                    switch (suit)
                    {
                        case 0:
                            card.cardSuit = "Diamonds";
                            break;
                        case 1:
                            card.cardSuit = "Hearts";
                            break;
                        case 3:
                            card.cardSuit = "Spades";
                            break;
                        default:
                            card.cardSuit = "Clubs";
                            break;
                    }
                    ////If statements assigs the suit to each card.
                    //if (suit == 0)
                    //{
                    //    card.cardSuit = "Diamonds";
                    //}
                    //else if (suit == 1)
                    //{
                    //    card.cardSuit = "Hearts";
                    //}
                    //else if (suit == 2)
                    //{
                    //    card.cardSuit = "Spades";
                    //}
                    //else if (suit == 3)
                    //{
                    //    card.cardSuit = "Clubs";
                    //}

                    //If statements that assign what the face value if each card is nby using the position in the loop.
                    //Ace can hold both a value of 1 and 11 ao it will be assigned later in the point addition phase.
                    switch (value)
                    {
                        case 14:
                            card.cardNumber = "Ace";
                            break;
                        case 13:
                            card.cardNumber = "King";
                            break;
                        case 12:
                            card.cardNumber = "Queen";
                            break;
                        case 11:
                            card.cardNumber = "Jack";
                            break;
                        default:
                            card.cardNumber = value.ToString();
                            break;
                    }

                    //if (value == 14)
                    //{
                    //    card.cardNumber = "Ace";
                    //}
                    //else if (value == 13)
                    //{
                    //    card.cardNumber = "King";
                    //}
                    //else if (value == 12)
                    //{
                    //    card.cardNumber = "Queen";
                    //}
                    //else if (value == 11)
                    //{
                    //    card.cardNumber = "Jack";
                    //}
                    //else
                    //{
                    //    card.cardNumber = value.ToString();
                    //}
                    if (value >= 10 && value < 14)
                    {
                        card.cardPointValue = 10;
                    }
                    else if (value < 10)
                    {
                        card.cardPointValue = value;
                    }

                    //Verifies that each card and its properties are created correctly.
                    Console.WriteLine("The {0} of {1} was created with a point value of {2}.", card.cardNumber, card.cardSuit, card.cardPointValue);

                    //Adds the new card into the deck.
                    DeckCreation.Add(card);
                }
            }
            //Verifies that the entire deck of 52 was created.
            Console.WriteLine("The card deck has {0} cards,\n", DeckCreation.Count);



        }   
    }
}