using System;
using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

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

    void RunPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("true");
        }
        else
        {
            Terminal.WriteLine("false");
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = level1passwords[3];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2passwords[3];
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = level3passwords[3];
            StartGame();
        }
    }


    void StartGame()
    {
        ShowMainMenu();
        currentScreen = Screen.Password;
        Terminal.WriteLine("Please Enter  Password:");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}