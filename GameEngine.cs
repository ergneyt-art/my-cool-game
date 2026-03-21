using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyCoolGame
{
    public class GameEngine
    {
        private readonly int  MaxCharacterCount = 4;
        private Dictionary<string, object> settings;
        private readonly string SettingsFilePath = @$"{AppContext.BaseDirectory}files\settings.json";
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> texts;
        private readonly string LocalizableTextsFilePath = @$"{AppContext.BaseDirectory}files\localizableStrings.json";
        private List<BaseCharacter> party = new List<BaseCharacter>();
        private BaseCharacter creatingCharacterInfo = new BaseCharacter();


        public void Run()
        {
            // InstallSettings();
            // InstallLocalizableTexts();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("Wellcome to my game");
            Console.WriteLine("1. Start new game");
            Console.WriteLine("2. Load game");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose option");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey) 
            {
                case ConsoleKey.D1:
                    StartNewGameMenu();
                    break;
                case ConsoleKey.D2:
                    LoadGame();
                    break;
                case ConsoleKey.D3:
                    ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    ShowMainMenu();
                    break;
            }

        }

        public void StartNewGameMenu()
        {
            Console.WriteLine("Starting new game...");
            Console.WriteLine("1. Create new character");
            Console.WriteLine("2. Change character");
            Console.WriteLine("3. Start Game");
            Console.WriteLine("4. Back");
            Console.WriteLine("Choose option");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey) 
            {
                case ConsoleKey.D1:
                    CreateCharacterMenu();
                    break;
                case ConsoleKey.D2:
                    ChangeCharacterMenu();
                    Console.WriteLine("Changing character...");
                    break;
                case ConsoleKey.D3:
                    StartGame();
                    break;
                case ConsoleKey.D4:
                    this.party = new List<BaseCharacter>();
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    StartNewGameMenu();
                    break;
            }
        }

        public void CreateCharacterMenu()
        {
            if (party.Count >= MaxCharacterCount)
            {
                Console.WriteLine("You can't create more characters");
                StartNewGameMenu();
                return;
            }

            Console.WriteLine($"Your current character: {creatingCharacterInfo.GetBaseInfo()}");
            Console.WriteLine("1. Choose class");
            Console.WriteLine("2. Choose race");
            Console.WriteLine("3. Choose gender");
            Console.WriteLine("4. Choose name");
            Console.WriteLine("5. Ready");
            Console.WriteLine("6. Back");

            ConsoleKey pressedKey = ConsoleKey.Escape;

            while (pressedKey != ConsoleKey.D5 || pressedKey != ConsoleKey.D6)
            {
                pressedKey = Console.ReadKey().Key;
                switch (pressedKey)
                {
                    case ConsoleKey.D1:
                        creatingCharacterInfo.Class = ChooseClass();
                        CreateCharacterMenu();
                        break;
                    case ConsoleKey.D2:
                        creatingCharacterInfo.Race = ChooseRace();
                        CreateCharacterMenu();
                        break;
                    case ConsoleKey.D3:
                        creatingCharacterInfo.Gender = ChooseGender();
                        CreateCharacterMenu();
                        break;
                    case ConsoleKey.D4:
                        creatingCharacterInfo.Name = ChooseName();
                        CreateCharacterMenu();
                        break;
                    case ConsoleKey.D5:
                        var character = ValidateCharacterInfo();
                        if (character != null)
                        {
                            party.Add(character);
                            this.creatingCharacterInfo = new BaseCharacter();
                            Console.WriteLine($"Character {character.Name} created");
                            Console.WriteLine($"Your party is:");
                            foreach (var partyMember in party)
                            {
                                Console.WriteLine(partyMember.GetBaseInfo());
                            }
                            StartNewGameMenu();
                        }
                        else
                        {
                            Console.WriteLine("Character info is not valid");
                            CreateCharacterMenu();
                        }
                        break;
                    case ConsoleKey.D6:
                        this.creatingCharacterInfo = new BaseCharacter();
                        StartNewGameMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        CreateCharacterMenu();
                        break;
                }
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Starting game...");
        }

        private BaseCharacter ValidateCharacterInfo()
        {
            if (string.IsNullOrEmpty(creatingCharacterInfo.Class))
            {
                Console.WriteLine("Class is not chosen");
                return null;
            }

            if (string.IsNullOrEmpty(creatingCharacterInfo.Race))
            {
                Console.WriteLine("Race is not chosen");
                return null;
            }

            if (string.IsNullOrEmpty(creatingCharacterInfo.Gender))
            {
                Console.WriteLine("Gender is not chosen");
            }

            if (string.IsNullOrEmpty(creatingCharacterInfo.Name))
            {
                Console.WriteLine("Name is not entered");
                return null;
            }

            switch (creatingCharacterInfo.Class)
            {
                case "Knight":
                    return new Knight
                    {
                        Class = creatingCharacterInfo.Class,
                        Name = creatingCharacterInfo.Name,
                        Gender = creatingCharacterInfo.Gender,
                        Race = creatingCharacterInfo.Race,
                    };
                case "Archer":
                    return new Archer
                    {
                        Class = creatingCharacterInfo.Class,
                        Name = creatingCharacterInfo.Name,
                        Gender = creatingCharacterInfo.Gender,
                        Race = creatingCharacterInfo.Race,
                    };
                case "Wizzard":
                    return new Wizzard
                    {
                        Class = creatingCharacterInfo.Class,
                        Name = creatingCharacterInfo.Name,
                        Gender = creatingCharacterInfo.Gender,
                        Race = creatingCharacterInfo.Race,
                    };
                case "Berserker":
                    return new Berserker
                    {
                        Class = creatingCharacterInfo.Class,
                        Name = creatingCharacterInfo.Name,
                        Gender = creatingCharacterInfo.Gender,
                        Race = creatingCharacterInfo.Race,
                    };
                case "Priest":
                    return new Priest
                    {
                        Class = creatingCharacterInfo.Class,
                        Name = creatingCharacterInfo.Name,
                        Gender = creatingCharacterInfo.Gender,
                        Race = creatingCharacterInfo.Race,
                    };
                default:
                    Console.WriteLine("Invalid class");
                    return null;
            }
        }



        private string ChooseClass()
        {
            Console.WriteLine("Choose class...");
            Console.WriteLine("1. Knight");
            Console.WriteLine("2. Archer");
            Console.WriteLine("3. Wizzard");
            Console.WriteLine("4. Berserker");
            Console.WriteLine("5. Priest");
            Console.WriteLine("6. Back");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                    return "Knight";
                case ConsoleKey.D2:
                    return "Archer";
                case ConsoleKey.D3:
                    return "Wizzard";
                case ConsoleKey.D4:
                    return "Berserker";
                case ConsoleKey.D5:
                    return "Priest";
                case ConsoleKey.D6:
                    return string.Empty;
                default:
                    Console.WriteLine("Invalid option");
                    return ChooseClass();
            }
        }

        private string ChooseRace()
        {
            Console.WriteLine("Choose race...");
            Console.WriteLine("1. Human");
            Console.WriteLine("2. Elf");
            Console.WriteLine("3. Dwarf");
            Console.WriteLine("4. Orc");
            Console.WriteLine("5. Back");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                    return "Human";
                case ConsoleKey.D2:
                    return "Elf";
                case ConsoleKey.D3:
                    return "Dwarf";
                case ConsoleKey.D4:
                    return "Orc";
                case ConsoleKey.D5:
                    return string.Empty;
                default:
                    Console.WriteLine("Invalid option");
                    return ChooseRace();
            }
        }

        private string ChooseGender()
        {
            Console.WriteLine("Choose gender...");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Back");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                    return "Male";
                case ConsoleKey.D2:
                    return "Female";
                case ConsoleKey.D3:
                    return string.Empty;
                default:
                    Console.WriteLine("Invalid option");
                    return ChooseGender();
            }
        }

        private string ChooseName()
        {
            Console.WriteLine("Enter name. Maximum 30 symbols");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can't be empty");
                return string.Empty;
            } 
            else if (name.Length > 30)
            {
                Console.WriteLine("Name can't be longer than 30 symbols");
                return string.Empty;
            }

            Console.WriteLine($"Your name is {name}");
            return name;
        }




        public void LoadGame()
        {
            Console.WriteLine("Loading game...");
        }

        public void ExitGame()
        {
            Console.WriteLine("Exiting game...");
            Environment.Exit(0);
        }

        /*
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
        */
    }
}
