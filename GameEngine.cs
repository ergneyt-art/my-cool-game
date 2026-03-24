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
        private int CurrentCharacterIndex = 0;


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
            Console.WriteLine("Your party is:");
            foreach (var partyMember in party)
            {
                Console.WriteLine(partyMember.GetBaseInfo());
            }
            Console.WriteLine("1. Create new character");
            Console.WriteLine("2. Change character");
            Console.WriteLine("3. Start Game");
            Console.WriteLine("4. Back");
            Console.WriteLine("Choose option");
            var pressedKey = Console.ReadKey().Key;
            switch (pressedKey) 
            {
                case ConsoleKey.D1:
                    CharacterMenu(CharacterMenuMode.NewCharacter);
                    break;
                case ConsoleKey.D2:
                    ChangeCharacterMenu();
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

        public void CharacterMenu(CharacterMenuMode mode)
        {
            if (party.Count >= MaxCharacterCount && mode == CharacterMenuMode.NewCharacter)
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

            pressedKey = Console.ReadKey().Key;
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                    creatingCharacterInfo.Class = ChooseClass();
                    CharacterMenu(mode);
                    break;
                case ConsoleKey.D2:
                    creatingCharacterInfo.Race = ChooseRace();
                    CharacterMenu(mode);
                    break;
                case ConsoleKey.D3:
                    creatingCharacterInfo.Gender = ChooseGender();
                    CharacterMenu(mode);
                    break;
                case ConsoleKey.D4:
                    creatingCharacterInfo.Name = ChooseName();
                    CharacterMenu(mode);
                    break;
                case ConsoleKey.D5:
                    var character = ValidateCharacterInfo();
                    if (character != null)
                    {
                        if (mode == CharacterMenuMode.NewCharacter)
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
                        else if (mode == CharacterMenuMode.ChangeCharacter)
                        {
                            party[CurrentCharacterIndex] = character;
                            this.creatingCharacterInfo = new BaseCharacter();
                            Console.WriteLine($"Character {character.Name} changed");
                            Console.WriteLine($"Your party is:");
                            foreach (var partyMember in party)
                            {
                                Console.WriteLine(partyMember.GetBaseInfo());
                            }
                            StartNewGameMenu();
                        }
                        else
                        {
                            Console.WriteLine("Invalid character menu mode");
                            StartNewGameMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Character info is not valid");
                        CharacterMenu(mode);
                    }
                    break;
                case ConsoleKey.D6:
                    this.creatingCharacterInfo = new BaseCharacter();
                    StartNewGameMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    CharacterMenu(mode);
                    break;
            }
        }

        public void ChangeCharacterMenu()
        {
            if (party.Count == 0)
            {
                Console.WriteLine("You don't have characters in your party");
                StartNewGameMenu();
                return;
            }
    
            Console.WriteLine("Choose character to change:");
            for (int i = 0; i < party.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {party[i].Name}");
            }
            Console.WriteLine($"{party.Count + 1}. Back");
            var pressedKey = Console.ReadKey().Key;
            if (pressedKey == ConsoleKey.D1 || pressedKey == ConsoleKey.D2 || pressedKey == ConsoleKey.D3 || pressedKey == ConsoleKey.D4)
            {
                int characterIndex = (int)pressedKey - (int)ConsoleKey.D1;
                if (characterIndex >= 0 && characterIndex < party.Count)
                {
                    this.creatingCharacterInfo = party[characterIndex];
                    this.CurrentCharacterIndex = characterIndex;
                    CharacterMenu(CharacterMenuMode.ChangeCharacter);
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    ChangeCharacterMenu();
                }
            }
            else if (pressedKey == ConsoleKey.D5)
            {
                StartNewGameMenu();
            }
            else
            {
                Console.WriteLine("Invalid option");
                ChangeCharacterMenu();
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
    }

    public enum CharacterMenuMode
    {
        NewCharacter = 1,
        ChangeCharacter = 2,
    }
}
