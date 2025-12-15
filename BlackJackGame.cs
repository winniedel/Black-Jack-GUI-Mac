using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackGUIMac
{
    public class BlackJackGame
    {
        private MainWindow window; // Reference to Avalonia MainWindow

        public int userWins = 0;
        public int houseWins = 0;

        private int[] shuffledDeck;
        private List<int> userCards;
        private List<int> houseCards;

        public BlackJackGame(MainWindow windowReference)
        {
            // store window reference
            window = windowReference;
            StartNewGame();
        }

        // Starts a new game
        public void StartNewGame()
        {
            // Clear previous messages in the Avalonia OutputBox
            window.OutputBox.Text = "";

            shuffledDeck = MakeShuffledDeck();
            userCards = new List<int>();
            houseCards = new List<int>();

            window.Print("Let's Start Playing Black Jack");
            window.Print("New Deck: " + string.Join(" , ", shuffledDeck));

            // Deal the first card to the user
            UserHit(); // deal first card automatically

           
        }

        // Called when the user hits
        public void UserHit()
        {
            int card = GiveCard(ref shuffledDeck);
            userCards.Add(card);
            // window.ShowCardImage(card); // optional, if you implement images

            // Dealer draws automatically if under 17
            if (houseCards.Sum() < 17)
            {
                int dealerCard = GiveCard(ref shuffledDeck);
                houseCards.Add(dealerCard);
            }

            window.Print("New Deck: " + string.Join(" , ", shuffledDeck));
            window.Print("Your Hand: " + string.Join(", ", userCards));
            window.Print("Dealer Hand: " + string.Join(", ", houseCards));

            // Check for bust or blackjack
            if (userCards.Sum() > 21)
            {
                window.Print("You're Busted! Dealer Wins.");
                IncrementHouseScore();
                ShowScores();
            }
            else if (userCards.Sum() == 21)
            {
                window.Print("Blackjack! You Win!");
                IncrementUserScore();
                ShowScores();
            }
            else
            {
                window.Print("Wanna Keep Playing? Press Hit, if Not Press Stand");
            }
        }

        // Called when the user stands
        public void UserStand()
        {
            // Dealer draws until 17 or higher
            while (houseCards.Sum() < 17)
            {
                int dealerCard = GiveCard(ref shuffledDeck);
                houseCards.Add(dealerCard);
                window.Print("Dealer drew: " + dealerCard);
            }

            window.Print("Final Hands:");
            window.Print("Your Hand: " + string.Join(", ", userCards));
            window.Print("Dealer Hand: " + string.Join(", ", houseCards));

            // Determine winner
            int userSum = userCards.Sum();
            int houseSum = houseCards.Sum();

            if (houseSum > 21 || userSum > houseSum)
            {
                window.Print("You Win!");
                IncrementUserScore();
            }
            else if (houseSum > userSum)
            {
                window.Print("Dealer Wins!");
                IncrementHouseScore();
            }
            else
            {
                window.Print("It's a Tie!");
            }

            ShowScores();
            window.Print("Wanna Play Again? Press 'New Game' to Continue");
        }

        // Method to show current scores
        private void ShowScores()
        {
            window.Print("Scores - House: " + GetHouseWins() + ", User: " + GetUserWins());
        }

        // Fisher-Yates shuffle algorithm
        private static void Shuffle(int[] array)
        {
            Random rand = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Creates and returns a shuffled deck of cards
        private int[] MakeShuffledDeck()
        {
            int[] array = new int[52];
            for (int i = 0; i < array.Length; i++)
                array[i] = (i % 13) + 1;
            Shuffle(array);
            return array;
        }

        // Gives a card from the deck and removes it from the deck
        private int GiveCard(ref int[] deck)
        {
            int card = deck[deck.Length - 1];
            int[] tempDeck = new int[deck.Length - 1];
            Array.Copy(deck, tempDeck, deck.Length - 1);
            deck = tempDeck;
            return card;
        }

        // Score management methods
        public void IncrementUserScore() { userWins++; }
        public void IncrementHouseScore() { houseWins++; }
        public int GetUserWins() { return userWins; }
        public int GetHouseWins() { return houseWins; }
    }
}
