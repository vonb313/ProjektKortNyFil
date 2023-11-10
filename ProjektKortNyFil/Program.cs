using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8; //För att stödja UTF-8

            //Skapr en ny lek av kort.
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);
            Console.WriteLine("---------------------------------------");

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort(); //sorterar kortlek
            Console.WriteLine(myDeck);
            Console.WriteLine("---------------------------------------");

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle(); //blandar kortlek
            Console.WriteLine(myDeck);
            Console.WriteLine("Lets play a game of highest card with two players.");
            Console.WriteLine("---------------------------------------");

            bool playagain = true; //Bool för att hålla koll på omspel.
            while (playagain)
            {
                int UserCards = Askforcards(); //Frågar användaren hur många kort som ska spelas med med hjälp av metoden. Input sparas i UserCards
                int PlayRounds = AskForRounds();//Frågar användaren hur många rundor som ska spelas med hjälp av metodeb. Input sparas i PlayRounds.
                Console.WriteLine("---------------------------------------");


                int rounds = 0; //För att hålla koll på räkningen av rundor.
                while (rounds < PlayRounds) //Loop som körs sålänge rounds är mindre än användarens val av rundor.
                {
                    HandOfCards player1 = new HandOfCards() { PlayerNumber = 1 }; //Skapar två spelarhänder för varje runda.
                    HandOfCards player2 = new HandOfCards() { PlayerNumber = 2 };
                    rounds++;
                    Console.WriteLine($"Round Nr: {rounds}");
                    Deal(myDeck, UserCards, player1, player2); //Delar ut kort till spelarna och skriver ut dem med hjälp av Deal metoden.
                    DetermineWinner(player1, player2); //Bestämmer vinnaren och skriver ut dem med hjälp av metoden.
                    if (rounds < PlayRounds) //Kontrollerar om Spelet är över eller om det finns en till runda.
                    {
                        Console.WriteLine("Press Enter to continue to next round⬇️");
                        Console.ReadKey();
                    }
                    else if (rounds == PlayRounds)
                    {
                        Console.WriteLine("🎮Game Over🎮 Thanks for playing👍");
                    }
                    Console.WriteLine("-------------------------------------");
                }
                playagain = PlayAgain(); //Metod som frågar om omspel. Kontrollerar While loopen ovan.
                myDeck.CreateFreshDeck(); //Skapar en ny lek om användaren vill spela igen.
            }
        }


        static int Askforcards() //metoden som frågar användaren hur många kort som ska spelas med.
        {
            int nrOfCards; //Variabel för att hålla antalet kort.
            while (true) //Loop som körs tills giltigt svar ges.
            {
                Console.WriteLine("How many cards do you want (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out nrOfCards) && nrOfCards >= 1 && nrOfCards <= 5) //läser in användarens svar och konverterar till integer om det går.
                {
                    return nrOfCards;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again!");
                }
            }
        }
        static int AskForRounds() //Snarlik metod som frågar efter rundor istället.
        {
            int nrOfRounds;
            while (true)
            {
                Console.WriteLine("How many rounds do you want to play (1-5)? ");
                if (int.TryParse(Console.ReadLine(), out nrOfRounds) && nrOfRounds >= 1 && nrOfRounds <= 5)
                {
                    return nrOfRounds;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again!");
                }
            }
        }
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2) //metoden som delar ut korten.
        {
            try // trycatch för att fånga fel och skriva ut de. Insåg senare att jag egentligen inte behöver denna. Men vill inte ta bort den eftersom jag blev nöjd att jag lyckades med den.
            {
                for (int i = 0; i < nrCardsToPlayer; i++)
                {
                    PlayingCard p1cards = myDeck.RemoveTopCard(); //Tar bort det översta kortet från leken.

                    if (p1cards != null) //Om det finns kort kvar i leken så läggs det till i Spelare 1 handen.
                    {
                        player1.Add(p1cards);
                        Console.WriteLine($"{p1cards} given to Player 1");
                    }
                    else
                    { //Om leken skulle vara tom, vilket den aldrig kommer va så skrivs detta meddelande ut.
                        Console.WriteLine("The deck is empty");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}"); //Skriver ut meddelandet från RemoveTopCard metoden i DeckOfCards classen.
            }

            Console.WriteLine();

            try //Samma lösning för att ge kort till spelare 2
            {
                for (int i = 0; i < nrCardsToPlayer; i++)
                {
                    PlayingCard p2cards = myDeck.RemoveTopCard();
                    if (p2cards != null)
                    {
                        player2.Add(p2cards);
                        Console.WriteLine($"{p2cards} given to Player 2");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine($"The deck now has {myDeck.Count} cards.");
            Console.WriteLine(player1);

            Console.WriteLine(player2);
        }
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2) //Metod som utger vinnare.
        {
            Console.WriteLine($"Player 1 Highest Card: {player1.Highest}"); //Skriver ut spelare 1 högsta kort
            Console.WriteLine($"Player 1 Lowest Card:  {player1.Lowest}\n"); //Skriver ut spelare 2 lägsta kort

            Console.WriteLine($"Player 2 Highest Card: {player2.Highest}");
            Console.WriteLine($"Player 2 Lowest Card:  {player2.Lowest}\n");

            if (player1.Highest.CompareTo(player2.Highest) > 0) // Om spelare 1 har högre kort
            {
                Console.WriteLine($"⭐⭐⭐⭐⭐⭐\n⭐Player 1⭐ wins this round with {player1.Highest} against {player2.Highest}\n⭐⭐⭐⭐⭐⭐\n");
            }
            else if (player1.Highest.CompareTo(player2.Highest) < 0) // Om spelare 2 har högre kort
            {
                Console.WriteLine($"⭐⭐⭐⭐⭐⭐\n⭐Player 2⭐ wins this round with {player2.Highest} against {player1.Highest}\n⭐⭐⭐⭐⭐⭐\n");
            }
            else //Om ingen av spelarna har högre kort än den andra.
            {
                Console.WriteLine($"{player1.Highest} against {player2.Highest}");
                Console.WriteLine("Look at that. Its a Tie!🤝");
            }
        }
        private static bool PlayAgain() //Metod som sköter om användaren vill spela igen.
        {
            while (true) //felhantering med hjälp av loop 
            {
                Console.WriteLine("Do you want to play again? Press 'Y' for Yes or 'N' for No");
                ConsoleKeyInfo key = Console.ReadKey(); //Läser inmatning av tangent.

                if (key.Key == ConsoleKey.Y) //Om tangent Y
                {
                    Console.WriteLine("\nOkay, let's play again ▶️");
                    return true;
                }
                else if (key.Key == ConsoleKey.N) // Om tangent N
                {
                    Console.Clear();
                    Console.WriteLine("⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐");
                    Console.WriteLine("⭐Thanks for playing my game🎮⭐Have a nice day!⭐");
                    Console.WriteLine("⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐");
                    return false;
                }
                else //Vid fel inmatning
                {
                    Console.WriteLine("\nWrong input. Press 'Y' or 'N'");
                }
            }

        }
    }
}


