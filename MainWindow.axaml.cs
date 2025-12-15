using Avalonia.Controls;
using Avalonia.Interactivity;

namespace BlackJackGUIMac
{
    public partial class MainWindow : Window
    {
        private BlackJackGame game;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the game
            game = new BlackJackGame(this);

            // Hook up button clicks
            HitButton.Click += HitButton_Click;
            StandButton.Click += StandButton_Click;
            NewGameButton.Click += NewGameButton_Click;
        }

        // Method to print text to the OutputBox
        public void Print(string message)
        {
            OutputBox.Text += message + "\n";
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            game.UserHit();
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            game.UserStand();
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            game.StartNewGame();
        }
    }
}

