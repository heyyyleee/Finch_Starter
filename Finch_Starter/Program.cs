using FinchAPI;
using System;

namespace Finch_Starter
{
    class Program
    {
        // *************************************************************
        // Application:     Finch Control

        // Author:          Hailey McGuire
        // Description:     Finch Starter - Talent Show
        // Application Type: Console
        // Date Created:    02/09/2021
        // Date Revised:    02/20/2021
        // *************************************************************

        static void Main(string[] args)
        {
            //
            // create a new Finch object
            //
            Finch myFinch;
            myFinch = new Finch();

            //
            // call the connect method
            //
            myFinch.connect();

            //
            // begin your code
            //

            MainAppTheme();

            DisplayWelcomeScreen();

            MainMenu();

            DisplayClosingScreen();

            //
            // call the disconnect method
            //
            myFinch.disConnect();
        }

        static void MainAppTheme()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        static void SecondaryAppTheme()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine("\tPress any key to continue: ");
            Console.ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t" + headerText);
            Console.WriteLine();
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            SecondaryAppTheme();

            Console.WriteLine();
            Console.WriteLine("\tWelcome to your new Finch Robot!");
            Console.WriteLine();
            Console.WriteLine("\tThis app will show you all the things your Finch can do.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            SecondaryAppTheme();

            Console.WriteLine();
            Console.WriteLine("\tThank you for using the Finch app!");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void MainMenu()
        {

            bool quit = false;
            string userInput;

            Console.Clear();
            MainAppTheme();

            Finch myFinch = new Finch();

            do
            {
                DisplayScreenHeader("\tMain Finch Menu");
                Console.WriteLine();
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tg) Feedback Menu");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t Enter your selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        DisplayConnectFinchRobot(myFinch);
                        break;

                    case "b":

                        TalentShowDisplayMenu(myFinch);
                        break;

                    case "c":

                        DataRecorderDisplayMenuScreen(myFinch);
                        break;

                    case "d":

                        AlarmSystemDisplayMenuScreen(myFinch);
                        break;

                    case "e":

                        UserProgrammingDisplayMenuScreen(myFinch);
                        break;

                    case "f":

                        DisplayDisconnectFinchRobot(myFinch);
                        break;

                    case "g":

                        FeedbackMenu();
                        break;

                    case "q":
                        DisplayClosingScreen();
                        quit = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease select a letter from the menu");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quit);
        }

        static void TalentShowDisplayMenu(Finch myFinch)
        {
            string userInput;
            bool quitTalentShowMenu = false;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                Console.WriteLine();
                Console.WriteLine("\tMake a Selection:");
                Console.WriteLine("\ta. Light and Sound");
                Console.WriteLine("\tb. Dance");
                Console.WriteLine("\tc. Mixing it Up");
                Console.WriteLine("\td. Return to Main Menu");
                Console.WriteLine();
                Console.Write("\tEnter your Selection: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        TalentShowDisplayDance(myFinch);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(myFinch);
                        break;

                    case "d":
                        MainMenu();
                        break;
                }

            } while (!quitTalentShowMenu);


        }

        static void TalentShowDisplayMixingItUp(Finch myFinch)
        {
            Console.Clear();
            Console.WriteLine();
            DisplayScreenHeader("Mixing it Up");
            Console.WriteLine();
            Console.WriteLine("\tHere are all of your Finch's talents all together!");

            for (int ledValue = 100; ledValue < 255; ledValue++)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
            }

            for (int ledValue = 255; ledValue > 100; ledValue--)
            {
                myFinch.setLED(ledValue, ledValue, ledValue);
            }

            myFinch.setLED(0, 255, 255);
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.wait(600);
            myFinch.noteOff();
            //myFinch.wait(100);
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(698);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOff();

            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setMotors(0, 0);

            myFinch.setLED(255, 255, 0);
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(1047);
            myFinch.wait(400);
            myFinch.noteOn(1174);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(784);
            myFinch.wait(600);

            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(600);
            myFinch.noteOff();
            myFinch.noteOn(523);
            myFinch.wait(200);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOff();

            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setLED(255, 255, 0);
            myFinch.setMotors(80, 80);
            myFinch.wait(200);
            myFinch.setLED(0, 255, 255);
            myFinch.setMotors(-80, -80);
            myFinch.wait(200);
            myFinch.setMotors(0, 0);

            myFinch.setLED(255, 255, 0);
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(1047);
            myFinch.wait(200);
            myFinch.noteOff();
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(1047);
            myFinch.wait(400);
            myFinch.noteOn(1174);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(784);
            myFinch.wait(600);

            myFinch.noteOff();
            myFinch.setLED(0, 0, 0);

            DisplayContinuePrompt();
        }

        static void TalentShowDisplayLightAndSound(Finch myFinch)
        {
            DisplayScreenHeader("Light and Sound");
            Console.WriteLine("\tHere is a light show and a song from your Finch!");

            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);
            myFinch.noteOn(988);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.wait(200);
            myFinch.noteOn(880);
            myFinch.wait(200);

            myFinch.noteOn(988);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.noteOn(587);
            myFinch.wait(400);

            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 255);
            myFinch.noteOn(784);
            myFinch.wait(400);
            myFinch.setLED(0, 0, 255);
            myFinch.noteOn(587);
            myFinch.wait(400);
            myFinch.setLED(255, 0, 0);
            myFinch.noteOn(659);

            myFinch.wait(400);
            myFinch.noteOn(659);
            myFinch.setLED(255, 0, 255);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.setLED(0, 0, 255);
            myFinch.wait(400);
            myFinch.noteOn(880);
            myFinch.setLED(255, 0, 0);
            myFinch.wait(400);
            myFinch.noteOn(784);
            myFinch.setLED(255, 0, 255);
            myFinch.wait(800);

            myFinch.setLED(0, 0, 0);
            myFinch.noteOff();

            DisplayContinuePrompt();

        }

        static void TalentShowDisplayDance(Finch myFinch)
        {
            Console.Clear();
            Console.WriteLine();
            DisplayScreenHeader("Dance");
            Console.WriteLine();
            Console.WriteLine("\tYour finch will now do a dance!");

            myFinch.setMotors(-80, 80);
            myFinch.wait(2000);
            myFinch.setMotors(80, -80);
            myFinch.wait(2000);
            myFinch.setMotors(100, 100);
            myFinch.wait(1000);
            myFinch.setMotors(-100, -100);
            myFinch.wait(1000);
            myFinch.setMotors(-100, 100);
            myFinch.wait(3000);

            myFinch.setMotors(80, -80);
            myFinch.wait(2000);
            myFinch.setMotors(-80, 80);
            myFinch.wait(2000);
            myFinch.setMotors(-100, -100);
            myFinch.wait(1000);
            myFinch.setMotors(100, 100);
            myFinch.wait(1000);
            myFinch.setMotors(100, -100);
            myFinch.wait(3000);

            myFinch.setMotors(300, 300);

            myFinch.setMotors(0, 0);

            DisplayContinuePrompt();
        }

        static bool DisplayConnectFinchRobot(Finch myfinch)
        {

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tConnecting the Finch robot now. Please be sure the USB cable is connected to the robot and computer.");
            Console.WriteLine();
            DisplayContinuePrompt();

            robotConnected = myfinch.connect();

            myfinch.setLED(0, 0, 0);
            myfinch.noteOff();

            return robotConnected;

        }

        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tDisconnecting from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine();
            Console.WriteLine("\tThe Finch robot is now disconnected.");
            DisplayContinuePrompt();

            MainMenu();
        }

        static void DataRecorderDisplayMenuScreen(Finch myFinch)
        {
            DisplayScreenHeader("Data Recorder");

            Console.WriteLine();
            Console.WriteLine("\tThis app is under construction.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void AlarmSystemDisplayMenuScreen(Finch myFinch)
        {
            DisplayScreenHeader("Alarm System");

            Console.WriteLine();
            Console.WriteLine("\tThis app is under construction.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void UserProgrammingDisplayMenuScreen(Finch myFinch)
        {
            DisplayScreenHeader("User Programming");

            Console.WriteLine();
            Console.WriteLine("\tThis app is under construction.");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        static void FeedbackMenu()
        {
            int userFeedback;
            string userResponse;
            bool validResponse;

            DisplayScreenHeader("Feedback Menu");

            do
            {
                Console.WriteLine();
                Console.WriteLine("\tThank you for using your Finch robot.");
                Console.WriteLine("\tPlease rate your experience from 1-5.");
                Console.WriteLine("\t1 is the worst, 5 is the best.");
                Console.WriteLine();
                Console.Write("\tYour rating: ");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out userFeedback);

                if (validResponse)
                {

                    if (userFeedback >= 3)
                    {
                        validResponse = true;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tThank you for your feedback! We are glad you enjoy your Finch robot.");
                        DisplayContinuePrompt();
                    }

                    else if (userFeedback < 3)
                    {
                        validResponse = true;
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("\tWe are sorry that you are not enjoying your Finch robot.");
                        DisplayContinuePrompt();

                    }
                }

                else if (!validResponse)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter an integer from 1 to 5.");
                }
            } while (!validResponse);
        }

    }
}
