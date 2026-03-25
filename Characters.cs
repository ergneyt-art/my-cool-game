using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolGame
{
    public class BaseCharacter : BaseCreature
    {
        public string Gender { get; set; }

        public string Class { get; set; }

        public string Race { get; set; }

        public int Intelligence { get; set; }

        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Perception { get; set; }

        public string GetBaseInfo()
        {
            return "Name: " + this.Name + "\n" +
                   "Level: " + this.Level + "\n" +
                   "Gender: " + this.Gender + "\n" +
                   "Class: " + this.Class + "\n" +
                   "Race: " + this.Race + "\n";
        }

        public BaseCharacter()
        {
        }
    }

    public class Knight : BaseCharacter
    {
        public Knight()
        {
            this.Health = 300;
        }
    }

    public class Archer : BaseCharacter
    {
        public Archer() 
        { 
            this.Health = 180;
        }
    }

    public class Wizzard : BaseCharacter
    {
        public Wizzard() 
        { 
            this.Health = 100;
        }
    }

    public class Berserker : BaseCharacter
    {
        public Berserker() 
        { 
            this.Health = 250;
        }

    }

    public class Priest : BaseCharacter
    {
        public Priest() 
        { 
            this.Health = 150;
        }
    }



}
