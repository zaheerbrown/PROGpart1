using System;
using System.IO;
using NAudio.Wave;  // Import NAudio namespaces

public class ChatBot
{
    public static void Main(string[] args)
    {
        Console.Clear();

        PlayVoiceGreeting();
        DisplayImage();

        PrintSeparator();
        GreetUser();
        PrintSeparator();

        StartChatLoop();
    }

    static void PlayVoiceGreeting()
    {
        string audioFilePath = "greeting.wav";

        if (File.Exists(audioFilePath))
        {
            try
            {
                // Use NAudio to play the audio
                using (var audioFile = new AudioFileReader(audioFilePath)) // Read the WAV file
                using (var outputDevice = new WaveOutEvent())           // Output to speakers
                {
                    outputDevice.Init(audioFile);  // Initialize the output device with the audio
                    outputDevice.Play();           // Play the audio file
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        // Wait for the audio to finish
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while playing the audio: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("The greeting audio file is missing.");
        }
    }

    static void DisplayImage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
         ________ ________  ________  ________  ________  ________      ________      __    __    
        |\   __  \\   __  \|\   __  \|\   __  \|\   __  \|\   __  \    |\   __  \    |\  |  |  |  
        \ \  \|\  \  \|\  \ \  \|\  \ \  \|\  \ \  \|\  \ \  \|\  \   \ \  \|\  \   \ \  |  |  |  
         \ \   ____\ \   __  \ \  \\\  \ \   ____\ \  \\\  \ \   __  \   \ \   ____\   \ \  |  |    
          \ \  \|\  \ \  \ \  \ \  \\\  \ \  \___| \ \  \\\  \ \  \ \  \   \ \  \___|    \ \  |  |    
           \ \______\ \__\ \__\ \_______\ \__\______\ \_______\ \__\ \__\   \ \__\        \ \__|__|    
            \|______|\|__|\|__|\|_______|\|_______|\|_______|\|__|\|__|    \|__|         \|__|__|  
        ");
        Console.ResetColor();
    }

    static void GreetUser()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        Console.ResetColor();

        Console.Write("What’s your name? ");
        string userName = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Hello, {userName}! I’m here to help you stay safe online.");
        Console.ResetColor();
    }

    static void HandleUserQuery(string userInput)
    {
        userInput = userInput.ToLower(); // Convert input to lowercase for better matching

        if (userInput.Contains("how are you"))
        {
            Console.WriteLine("I'm great, thank you! How can I assist you today?");
        }
        else if (userInput.Contains("what’s your purpose") || userInput.Contains("what is your purpose"))
        {
            Console.WriteLine("I help you stay safe online by providing cybersecurity tips!");
        }
        else if (userInput.Contains("password safety"))
        {
            Console.WriteLine("Use strong, unique passwords for each account. Consider using a password manager!");
        }
        else if (userInput.Contains("what can i ask") || userInput.Contains("help"))
        {
            Console.WriteLine("You can ask me about:\n - Password Safety\n - Phishing Scams\n - Malware Protection\n - Safe Browsing\n - Online Privacy\n - Social Media Security");
        }
        else if (userInput.Contains("phishing"))
        {
            Console.WriteLine("Phishing scams trick you into revealing personal information. Never click suspicious links or enter credentials on unknown sites.");
        }
        else if (userInput.Contains("malware"))
        {
            Console.WriteLine("Malware is harmful software like viruses or ransomware. Keep your system updated and avoid downloading files from untrusted sources.");
        }
        else if (userInput.Contains("safe browsing"))
        {
            Console.WriteLine("Always check for HTTPS on websites, avoid clicking unknown links, and use a trusted antivirus program.");
        }
        else if (userInput.Contains("online privacy"))
        {
            Console.WriteLine("Use two-factor authentication, review privacy settings on social media, and avoid sharing too much personal information.");
        }
        else if (userInput.Contains("social media security"))
        {
            Console.WriteLine("Use strong passwords, enable two-factor authentication, and be cautious about sharing personal information online.");
        }
        else if (userInput.Contains("exit") || userInput.Contains("quit"))
        {
            Console.WriteLine("Goodbye! Stay safe online.");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("I didn’t quite understand that. Could you rephrase?");
        }
    }

    static void StartChatLoop()
    {
        while (true)
        {
            Console.WriteLine("\nAsk me something about cybersecurity (or type 'exit' to quit):");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter a valid question.");
            }
            else
            {
                HandleUserQuery(userInput);
            }
        }
    }

    static void PrintSeparator()
    {
        Console.WriteLine(new string('-', 50));
    }
}
