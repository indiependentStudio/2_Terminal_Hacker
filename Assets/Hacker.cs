using UnityEngine;
public class Hacker : MonoBehaviour {
    // game config
    enum Screen { MainMenu, Password, Win };
    string[] level1passwords = { "twins", "sisters", "mulan", "cat", "dog" };
    string[] level2passwords = { "shortbread", "ipad", "facebook", "wow", "shoes" };
    string[] level3passwords = { "aaaaa", "bbbbb", "coding", "gaming", "mulan" };
    // member (state) variables
    int level;
    Screen currentScreen;
    string password;
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
        if (input == "menu") {
            ShowMainMenu("Welcome back, Mr Dave.");
        } else if (currentScreen == Screen.MainMenu) {
            ProcessMenuInput(input);
        } else if (currentScreen == Screen.Password) {
            ProcessPasswordGuess(input);
        }
    }
    void ProcessMenuInput(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        } else {
            Terminal.WriteLine("Please enter a valid option.");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your guess.");
       SetPasswordForLevel();
    }

    void SetPasswordForLevel()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            default:
                // shouldn't be able to get here
                Debug.Log("Invalid level");
                break;
        }
    }

    void ProcessPasswordGuess(string input)
    {
        if (input == password) {
            DisplayWin();
        } else {
            TryAgain();
        }
    }
    void TryAgain()
    {
        Terminal.WriteLine("Try again");
    }
    void DisplayWin()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Gratz, you are IN sir!");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter \"menu\" to start again");
    }
} // end class Hacker