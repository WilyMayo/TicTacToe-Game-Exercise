using System;
using System.Collections.Generic;

namespace TicTacToeExercise
{
    class Program
    {
        // the playing field 
        static char[,] fieldNumbers =
        {
          //  0   1   2  // colomn

            {'1','2','3'}, // row 0
            {'4','5','6'}, // row 1
            {'7','8','9'} //  row 2

        };



        static int turnsPlayed = 0;

        static void Main(string[] args)
        {
            int player = 2; // player 1 starts 
            int input = 0;  // user input 
            bool inputCorrect = true;  // check input is right 


            // Run code as long as the program runs 
            do
            {
                

                if (player == 2)
                {
                    player = 1;
                    XxorOo(player, input);
                }
                else if(player == 1)
                {
                    player = 2;
                    XxorOo(player, input);
                }

                TheField(); // set field on do while to clear the field and saw input changing 

                #region
                // Check winning condition
                //if 1,4,7 && 2,5,8 && 3,6,9 && 3,5,7 && 1,5,9 && 1,,2,3 && 4,5,6 && 7,8,9 are X or O {ifso player with playersign X or O wins }
                char[] playerChars = { 'X', 'O' };
                foreach (char playerChar in playerChars)
                {
                    if ((fieldNumbers[0, 0] == playerChar && fieldNumbers[1, 0] == playerChar && fieldNumbers[2, 0] == playerChar)
                        || (fieldNumbers[0, 1] == playerChar && fieldNumbers[1, 1] == playerChar && fieldNumbers[2, 1] == playerChar)
                        || (fieldNumbers[0, 2] == playerChar && fieldNumbers[1, 2] == playerChar && fieldNumbers[2, 2] == playerChar)
                        || (fieldNumbers[0, 2] == playerChar && fieldNumbers[1, 1] == playerChar && fieldNumbers[2, 0] == playerChar)
                        || (fieldNumbers[0, 0] == playerChar && fieldNumbers[1, 1] == playerChar && fieldNumbers[2, 2] == playerChar)
                        || (fieldNumbers[0, 0] == playerChar && fieldNumbers[0, 1] == playerChar && fieldNumbers[0, 2] == playerChar)
                        || (fieldNumbers[1, 0] == playerChar && fieldNumbers[1, 1] == playerChar && fieldNumbers[1, 2] == playerChar) 
                        || (fieldNumbers[2, 0] == playerChar && fieldNumbers[2, 1] == playerChar && fieldNumbers[2, 2] == playerChar))

                    { if (playerChar == 'X') { Console.WriteLine(" \n Player 1 has won. "); }
                        else if (playerChar == 'O') { Console.WriteLine(" \n Player 2 has won. "); }

                        // TODO reset field when winning condition is meet.
                        Console.WriteLine(" Please press any key to play again.");
                        Console.ReadKey();
                        ResetField();
                        
                        break;
                    }
                    else if (turnsPlayed == 10) { Console.WriteLine(" DRAW! "); Console.WriteLine(" Please press any key to play again. "); Console.ReadKey(); ResetField(); } break;
                }

                #endregion


                #region
                // Test if field is already used 
                do
                {
                    Console.WriteLine("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a number!");
                        
                    }
                    if((input == 1) && (fieldNumbers[0,0] == '1')) { inputCorrect = true; }
                    else if ((input == 2) && (fieldNumbers[0,1] == '2')) { inputCorrect = true; }
                    else if ((input == 3) && (fieldNumbers[0, 2] == '3')) { inputCorrect = true; }
                    else if ((input == 4) && (fieldNumbers[1, 0] == '4')) { inputCorrect = true; }
                    else if ((input == 5) && (fieldNumbers[1, 1] == '5')) { inputCorrect = true; }
                    else if ((input == 6) && (fieldNumbers[1, 2] == '6')) { inputCorrect = true; }
                    else if ((input == 7) && (fieldNumbers[2, 0] == '7')) { inputCorrect = true; }
                    else if ((input == 8) && (fieldNumbers[2, 1] == '8')) { inputCorrect = true; }
                    else if ((input == 9) && (fieldNumbers[2, 2] == '9')) { inputCorrect = true; }
                    else
                    {
                        Console.WriteLine("\n Incorrect input! Please use another field!");
                        inputCorrect = false;
                    }
                    


                } while (!inputCorrect);
#endregion               

            } while (true);

        }


        public static void ResetField()
        {
            char[,] newFieldNumbers =
            {
              //  0   1   2  // colomn

                {'1','2','3'}, // row 0
                {'4','5','6'}, // row 1
                {'7','8','9'} //  row 2
            };

            fieldNumbers = newFieldNumbers;
            turnsPlayed = 0;
            TheField();
            
        }

        public static void TheField()
        {
            Console.WriteLine(" Welcome to \n  TIC TAC TOE \n");
            Console.Clear();

            Console.WriteLine("    |     |    ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0} |  {1}  |  {2} ", fieldNumbers[0,0],fieldNumbers[0,1],fieldNumbers[0,2]);
            Console.WriteLine("____|_____|____");
            Console.WriteLine("    |     |    ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0} |  {1}  |  {2} ", fieldNumbers[1,0], fieldNumbers[1,1], fieldNumbers[1,2]);
            Console.WriteLine("____|_____|____");
            Console.WriteLine("    |     |    ");
            //TODO replace numbers with variables
            Console.WriteLine("  {0} |  {1}  |  {2} ", fieldNumbers[2,0], fieldNumbers[2,1], fieldNumbers[2,2]);
            Console.WriteLine("____|_____|____");
            Console.WriteLine("    |     |    ");
            turnsPlayed++;
            
        }
        public static void XxorOo( int player, int input)
        {
            char playersign = ' ';

            if(player == 1) { playersign =  'O'; }
            else if(player == 2) { playersign = 'X'; }

            switch (input)
            {
                case 1: fieldNumbers[0, 0] = playersign; break;
                case 2: fieldNumbers[0, 1] = playersign; break;
                case 3: fieldNumbers[0, 2] = playersign; break;
                case 4: fieldNumbers[1, 0] = playersign; break;
                case 5: fieldNumbers[1, 1] = playersign; break;
                case 6: fieldNumbers[1, 2] = playersign; break;
                case 7: fieldNumbers[2, 0] = playersign; break;
                case 8: fieldNumbers[2, 1] = playersign; break;
                case 9: fieldNumbers[2, 2] = playersign; break;
            }
        }
    }
}
