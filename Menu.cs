using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace MyCoolGame
{
    public static class Menu // add commets
    {
        public static string Lang { get; set; } = "RU";
        public static Localizable Localizable { get; set; } = new Localizable();

        public static void ShowMainMenu()
        {
            Console.WriteLine(Localizable.GetTextByName("Greetings", Lang));
            Console.WriteLine($"1. {Localizable.GetTextByName("StartGame", Lang)}");
            Console.WriteLine($"2. {Localizable.GetTextByName("LoadGame", Lang)}");
            Console.WriteLine($"3. {Localizable.GetTextByName("Settings", Lang)}");
            Console.WriteLine($"4. {Localizable.GetTextByName("Exit", Lang)}");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey) 
            {
                case ConsoleKey.D1:
                    StartNewGame();
                    break;
                case ConsoleKey.D2:
                    LoadGame();
                    break;
                case ConsoleKey.D3:
                    ShowSettings(); 
                    break;
                case ConsoleKey.D4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(Localizable.GetTextByName("ErrorInvalidOpinion", Lang));
                    ShowMainMenu();
                    break;
            }

        }

        public static void StartNewGame()
        {

        }

        public static void LoadGame()
        {

        }

        public static void ShowSettings()
        {

        }
    }

    public interface IGetInfo
    {
        public void ShowInfo(object obj)
        {

        }
    }

    public interface IMoveing
    {
        public void Move()
        {

        }

        public void Jump()
        {

        }

        public void Turn()
        {

        }

        public void Stop()
        {

        }
    }
}

public class Localizable
{
    private readonly string LocalizableFilePath = @"C:\Users\Ergney\source\repos\MyCoolGame\MyCoolGame\files\localizableStrings.json";

    private List<LocalizableText> texts = new List<LocalizableText>();

    public Localizable()
    {
        if (File.Exists(LocalizableFilePath))
        {
            using (StreamReader reader = new StreamReader(LocalizableFilePath))
            {
                string json = reader.ReadToEnd();
                texts = JsonSerializer.Deserialize<List<LocalizableText>>(json);
            }
        }
    }

    public string GetTextByName(string name, string lang)
    {
        var localizableString = this.texts.Where(e => e.Name == name).FirstOrDefault();
        if (localizableString != null)
        {
            return localizableString.Translations[lang];
        }
        
        throw new NotImplementedException();

    }

    public List<LocalizableText> GetTextByCategory(string category)
    {
        var localizableStrings = this.texts.Where(e => e.Category == category).ToList();
        if (localizableStrings != null)
        {
            return localizableStrings;
        }

        throw new NotImplementedException();
    }
}

public class  LocalizableText
{
    public string Name { get; set; }
    public string Category { get; set; }

    public Dictionary<string, string> Translations = new Dictionary<string, string>();
}