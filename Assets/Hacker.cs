using System;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    string[] level1passwords = { "redbull", "oreo", "camel", "snickers" };
    string[] level2passwords = { "intervention", "barret", "desereagle", "snickers" };
    string[] level3passwords = { "panzerkampfwagen", "oreo", "camel", "snickers" };


    int level;
    string password;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.MainMenu;

    //stuff to use
    string menuHint = "Type menu to restart!";

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    //main menu list
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?:\n\n" +
            "1.Convenience store\n" +
            "2.weapens\n" +
            "3.Tonks\n\n" +
            "Choose y no:-");
    }

    // OnUserInput is called when return is clicked 
    void OnUserInput(string input)
    {
        
        if (input == "menu")
        {
            currentScreen = Screen.MainMenu;
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            RunPassword(input);
        }
    }
    
    //password checker
    void RunPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("true");
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }


    //main menu functionality
    void RunMainMenu(string input)
    {
        int intInput = int.Parse(input);
        print(intInput);
        if (intInput >= 1 && intInput <= 3 )
        {
            level = intInput;
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("please choose valid");
        }
    }

    //beyond choose level
    void AskForPassword()
    {
        Terminal.ClearScreen();
        SetRandomPassword();
        currentScreen = Screen.Password;
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter Password!. Hint:" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[UnityEngine.Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[UnityEngine.Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[UnityEngine.Random.Range(0, level3passwords.Length)];
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //handle winning screen
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        DisplayArt();
        Terminal.WriteLine(menuHint);
    }

    void DisplayArt()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
mmmm
      _____________,-.___     _
     |____        { {]_]_]   [_]
     |___ `-----.__\ \_]_]_    . `
     |   `-----.____} }]_]_]_   ,
     |_____________/ {_]_]_]_] , `
"
                );
                break;
            case 2:
                Terminal.WriteLine(@"
  _  __________=__A
   \\@([____]_____()
  _/\|-[____]
 /     /(( )
/____|'----'
\____/

"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
    TONK! 
       _\______
      /        \========
 ____|__________\_____
/ ___________________ \
\/{oOOOOOOOOOOOOOOOo}\/
  \o%%%%%%%%%%%%%%%o/
"
                );
                break;

        }
    }
}