using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace BlackJack
{
    internal class PointCalculations
    {
        public string IfBust(int points)
        {
            string cont;
            if (points > 21)
            {
                Console.WriteLine("   You Busted, You have {0} points.", points);
                cont = "n";
                
            }
            else
            {
                Console.WriteLine("   Points = {0}", points);
                Console.WriteLine();
                Console.WriteLine("   Press y and enter to receive next card, any other key to pass.");
                cont = Console.ReadLine();
                
            }
            return cont;

        }

        public static void WinorLoose(int dealerPoints, int playerPoints)
        {
            if (playerPoints > 21)
            {
                Console.WriteLine("   You Lost because You Busted");
            }
            else if (dealerPoints > 21)
            {
                Console.WriteLine("   Dealer Busted, You Win!!!");
            }
            else if (dealerPoints < playerPoints)
            {
                Console.WriteLine("   You Win!!!!!");
            }
            else if (dealerPoints == playerPoints)
            {
                Console.WriteLine("   You Pushed");
            }
            else
            {
                Console.WriteLine("   You Lost");
            }
        }
    }
}
