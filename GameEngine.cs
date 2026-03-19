using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyCoolGame
{
    public class GameEngine
    {
        private Dictionary<string, object> settings;
        private readonly string SettingsFilePath = @$"{AppContext.BaseDirectory}files\settings.json";
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> texts;
        private readonly string LocalizableTextsFilePath = @$"{AppContext.BaseDirectory}files\localizableStrings.json";

        public void Run()
        {
            InstallSettings();
            InstallLocalizableTexts();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            var lang = settings["Lang"].ToString();
            Console.WriteLine($"{texts["MainMenu"]["Greetings"][lang]}");
            Console.WriteLine("1. " + texts["MainMenu"]["StartGame"][lang]);
            Console.WriteLine("2. " + texts["MainMenu"]["LoadGame"][lang]);
            Console.WriteLine("3. " + texts["MainMenu"]["Settings"][lang]);
            Console.WriteLine("4. " + texts["MainMenu"]["Exit"][lang]);
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
                    Console.WriteLine(texts["Errors"]["ErrorInvalidOpinion"][lang]);
                    ShowMainMenu();
                    break;
            }
        }

        public void StartNewGame()
        {
            Console.WriteLine("Starting new game...");
        }

        public void LoadGame()
        {
            Console.WriteLine("Loading game...");
        }

        public void ShowSettings()
        {
            var lang = settings["Lang"].ToString();
            Console.WriteLine(texts["Settings"]["SettingsTitle"][lang]);
            var counter = 1;
            var settingDict = new Dictionary<int, string>();
            foreach (var setting in settings)
            {
                var settingName = texts["Settings"][setting.Key][lang];
                var settingValue = setting.Value.ToString();
                
                if (texts["Settings"].ContainsKey(settingValue))
                {
                    settingValue = texts["Settings"][settingValue][lang];
                }
                Console.WriteLine($"{counter}. {settingName}: {settingValue}");
                settingDict.Add(counter, settingName);
                counter++;
            }
            Console.WriteLine($"{counter}. " + texts["Settings"]["Back"][lang]);
            Console.WriteLine(texts["Settings"]["ChooseSetting"][lang]);
            if (int.TryParse(Console.ReadLine(), out int enteredValue) && enteredValue > 0 && enteredValue <= counter)
            {
                counter = 1;
                var valueDict = new Dictionary<int, string>();
                foreach (var settingValue in texts[settingDict[enteredValue]])
                {
                    Console.WriteLine($"{counter}. {settingValue.Value[lang]}");
                    valueDict.Add(counter, settingValue.ToString());
                    counter++;
                }
                Console.WriteLine(texts["Settings"]["ChooseSettingValue"][lang]);
            }
            
        }



        private void InstallSettings()
        {
            Console.WriteLine("Installing settings...");
            if (File.Exists(SettingsFilePath))
            {
                using (StreamReader reader = new StreamReader(SettingsFilePath))
                {
                    string json = reader.ReadToEnd();
                    settings = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                }
                Console.WriteLine("Complited");
            }
            else
            {
                Console.WriteLine("Settings file not found");
            }
            
        }

        private void InstallLocalizableTexts()
        {
            Console.WriteLine("Installing localizable texts...");
            if (File.Exists(LocalizableTextsFilePath))
            {
                using (StreamReader reader = new StreamReader(LocalizableTextsFilePath))
                {
                    string json = reader.ReadToEnd();
                    var localizableStrings = JsonSerializer.Deserialize<List<LocalizableText>>(json);
                    texts = Localizable.GetTexts(localizableStrings);
                }
                Console.WriteLine("Complited");
            }
            else
            {
                Console.WriteLine("Localizable texts file not found");
            }

        }
    }
}
