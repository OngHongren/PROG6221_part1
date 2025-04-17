using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis; // Speech synthesis for voice greeting

namespace CyberSecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayAsciiArt(); // Show ASCII art first
            VoiceGreeting();   // Play the welcome message afterward
            HandleUserInput(); // Get user's name & interact
        }

        // Function for ASCII art display
        static void DisplayAsciiArt()
        {
            Console.WriteLine(@"
╔═══╗     ╔══╗      ╔╗ 
║╔═╗║     ║╔╗║     ╔╝╚╗
║║ ╚╝╔╗ ╔╗║╚╝╚╗╔══╗╚╗╔╝
║║ ╔╗║║ ║║║╔═╗║║╔╗║ ║║ 
║╚═╝║║╚═╝║║╚═╝║║╚╝║ ║╚╗
╚═══╝╚═╗╔╝╚═══╝╚══╝ ╚═╝
     ╔═╝║              
     ╚══╝              

            ");
        }

        // Function for voice greeting
        static void VoiceGreeting()
        {
            string startMessage = "Welcome to the Cybersecurity Awareness Assistant! I am Cybot";
            Console.WriteLine(startMessage);
            SpeechSynthesizer startSynth = new SpeechSynthesizer();
            startSynth.Speak(startMessage);
            
        }

        // Function for handling user interaction with input validation
        static void HandleUserInput()
        {
            string userName = "";

            // Loop until a valid name is entered
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Hello! What's your name?");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("Oops! You didn't enter a name. Please try again.");
                }
            }

            Console.WriteLine($"Nice to meet you, {userName}! I'm here to help with cybersecurity questions.");

            // Loop to ensure the user only enters "yes" or "no"
            string response = "";
            while (response != "yes" && response != "no")
            {
                Console.WriteLine("Would you like to ask me a cybersecurity question? (yes/no)");
                response = Console.ReadLine().ToLower();

                if (response != "yes" && response != "no")
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }

            if (response == "yes")
            {
                HandleCyberSecurityFAQs(); // Proceed to cybersecurity FAQs
            }
            else
            {
                Console.WriteLine("No problem! I'm here if you need help later.");
            }
        }

        // Function for handling cybersecurity FAQs with continuous loop
        static void HandleCyberSecurityFAQs()
        {
            // Dictionary of FAQs and responses
            Dictionary<int, string> faqResponses = new Dictionary<int, string>()
            {
                { 1, "Use strong passwords with a mix of letters, numbers, and symbols. Consider using a password manager." }, // Password Safety
                { 2, "Be cautious of unsolicited emails and suspicious links. Always verify the sender before clicking." }, // Phishing
                { 3, "Use secure websites (look for HTTPS), enable firewalls, and avoid downloading unknown files." } // Safe Browsing
            };

            bool askAnotherQuestion = true; // Loop control variable

            while (askAnotherQuestion)
            {
                Console.WriteLine("Which cybersecurity topic would you like to learn about?");
                Console.WriteLine("1 - Password Safety");
                Console.WriteLine("2 - Phishing");
                Console.WriteLine("3 - Safe Browsing");

                int selectedOption = 0;

                // Loop until the user enters a valid number (1, 2, or 3)
                while (!faqResponses.ContainsKey(selectedOption))
                {
                    Console.WriteLine("Please enter a number (1, 2, or 3):");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out selectedOption) && faqResponses.ContainsKey(selectedOption))
                    {
                        Console.WriteLine(faqResponses[selectedOption]); // Display the selected response
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    }
                }

                // Loop to ensure the user only enters "yes" or "no" to continue or exit
                string continueResponse = "";
                while (continueResponse != "yes" && continueResponse != "no")
                {
                    Console.WriteLine("Would you like to ask another cybersecurity question? (yes/no)");
                    continueResponse = Console.ReadLine().ToLower();

                    if (continueResponse != "yes" && continueResponse != "no")
                    {
                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                    }
                }

                // If user chooses "no", exit the loop
                askAnotherQuestion = continueResponse == "yes";
            }

            string goodbyeMessage = "Thank you for using the Cybersecurity Awareness Assistant! Stay safe online.";
            Console.WriteLine(goodbyeMessage);
            SpeechSynthesizer goodbyeSynth = new SpeechSynthesizer();
            goodbyeSynth.Speak(goodbyeMessage);
        }
    }
}





