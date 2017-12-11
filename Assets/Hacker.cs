using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    enum Screen { MainMenu, Password, Win };

    // member variables
    int level;
    Screen currentScreen;

	// Use this for initialization
	void Start () {
        ShowMainMenu("Good Evening, Dave");
	}

    void ShowMainMenu(string greeting) {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1. Avery's Diary");
        Terminal.WriteLine("2. Mummy's iPad");
        Terminal.WriteLine("3. Daddy's Server");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter the corresponding number.");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Welcome back, Mr Dave.");
        } else if (currentScreen == Screen.MainMenu)
        {
            ProcessMenuInput(input);
        }
    }

    void ProcessMenuInput(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please enter a valid option.");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("Starting Level " + level);
        currentScreen = Screen.Password;
    }
}
