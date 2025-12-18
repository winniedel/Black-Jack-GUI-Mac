Cross Platform Blackjack Game - mac(Avalonia

This is the Mac GUI version Blackjack game built in C#. The application features a user controled event driven interface. The GUI updates based on the selections of the player

Getting Started: 
-User will need macOs
-.Net 8 SDK
-Terminal/Command Line access

Steps to Run: 
-Clone repository 
(https://github.com/winniedel/Black-Jack-GUI-Mac.git)
-cd BlackJackGUIMac
-dotnet build
-dotnet run
-The Avalonia GUI will launch, and you will be able to play the Blackjack game with Hit, Stand, and New Game functionality

Players will be able to: 
-View their current hand 
-Choose to Hit or Stand during each round 
-Select a New Game to restart the program 
-Track their individual score along with the dealers'

Gameplay: -The player starts with one card from a shuffled deck, and can either choose to Hit or Stand 
-The dealer automatically draws from the same shuffled deck until they reach a total of 17 or higher 
-Scores update and iterate by one based off of the round's winner 
-Clicking 'New Game' clears the board for a new round

Screenshot/Recording: macOS GUI
[Avalonia GUI] image: (Black-Jack-GUI-Mac/BlackJack image.png)
[Avalonia GUI] recording:(https://www.youtube.com/watch?v=aKFlRVL9OEQ)


**NOTE: This GUI is only suitable for macOS devices. For Windows GUI using WinForms please refer to repository [Black-Jack-GUI-WinForms] or follow the link: (https://github.com/winniedel/Black-Jack-GUI-WinForms)**
