using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration Data
    string[] level1Passwords = {"cat", "dog", "bird", "yaboy" };
    string[] level2Passwords = { "harder", "faster", "stronger", "dumber" };
    string[] level3Passwords = { "something", "because", "strawberry", "yesterday" };

    // Game State

    const string menuHint = "You may enter 'menu' anytime to exit.";
    int level;
    string password;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    } 

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello");
        Terminal.WriteLine("What do you want to attempt to access?:");
        Terminal.WriteLine("Press 1 for the local library.");
        Terminal.WriteLine("Press 2 for the California Highway Patrol Database.");
        Terminal.WriteLine("Press 3 for the [undefined].");
        Terminal.WriteLine("Enter your selection: ");
    }
    //this is a message as it calls it outside the program
    void OnUserInput(string input)
    {
        if (input == "menu")  // we can always go direct to main menu
        {

            ShowMainMenu();
        } 
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)  
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "suck it")
        {
            Terminal.WriteLine("YOU suck it!");
            Terminal.WriteLine("please make a valid selection");

        }
        else
        {
            Terminal.WriteLine("please make a valid selection");
            
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Entry");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Congrats, you beat level 1!");
                Terminal.WriteLine(@"
     ____________
    /           //
   /           //
  /           //
 /___________//
(___________//
"
                );
                Terminal.WriteLine(menuHint);
                break;
            case 2:
                Terminal.WriteLine("Congrats, you beat level 2!");
                Terminal.WriteLine(@"
     ____________      ____________
    /           //    /            //
   /           //    /            //
  /           //    /            //
 /___________//    /____________//
(___________//    (____________//
"
                );
                Terminal.WriteLine(menuHint);
                break;
            case 3:
                Terminal.WriteLine("Congrats, you beat level 3!");
                Terminal.WriteLine(@"
       ____________         
      /   /\      // 
     /   /  \    //  
    /   /____\  //    
   /___________//      
  (___________//       
"
                );
                Terminal.WriteLine(menuHint);
                break;
        }
    }
}
