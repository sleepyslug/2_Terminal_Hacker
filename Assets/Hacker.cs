using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration Data
    string[] level1Passwords = {"cat", "dog", "bird", "yaboy" };
    string[] level2Passwords = { "harder", "faster", "stronger", "dumber" };

    // Game State
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
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "suck it")
        {
            Terminal.WriteLine("YOU suck it!");
        }
        else
        {
            Terminal.WriteLine("please make a valid selection");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Entry");
                break;
        }
        Terminal.WriteLine("Please enter your password: ");
                
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Congrats, you win!");
        }
        else
        {
            Terminal.WriteLine("Sorry, guess again");
            Terminal.WriteLine("Please enter your password: ");
        }
    }
}
