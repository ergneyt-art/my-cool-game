using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolGame
{
    #region Base Objects
    public abstract class BaseCreature : ISpell, IMoveing, IGetInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int BaseExperience { get; set; } = 1;

        public int Level { get; set; }

        public int Health { get; set; }

        public int Speed { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Defense { get; set; }

        public CreatureSize Size { get; set; }

        public List<BaseSpell> Spells { get; set; }
    }

    public abstract class BaseMonster : BaseCreature
    {
        public DefenseType DefenseType { get; set; }

        public CreatureSize Size { get; set; }

        public CreatureType Type { get; set; }

        public CreatureRarity Rarity { get; set; }

        public BehaviorPattern Behavior { get; set; }

        public void SetLevel(int level)
        {
            Level = level;
            Health = 10 + (level * 2);
            Speed = 5 + (level / 2);
            Strength = 2 + (level / 3);
            Intelligence = 1 + (level / 4);
            Defense = 1 + (level / 5);
        }


        public void GetHit(BaseSpell spell)
        {

        }

        public void UseSpell(BaseSpell spell, BaseCreature target)
        {

        }
    }

    public enum DefenseType
    {
        Nothing,
        Light,
        Mediume,
        Heavy,
        Magic
    }

    public enum CreatureSize
    {
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

    public enum CreatureType
    {
        Humanoid,
        Beast,
        Undead,
        Elemental,
        Dragon,
        Giant,
        Demon,
        Angel,
        Construct,
        Fey
    }

    public enum CreatureRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Mythic
    }

    public enum BehaviorPattern
    {
        LawfulGood,
        NeutralGood,
        ChaoticGood,
        LawfulNeutral,
        TrueNeutral,
        ChaoticNeutral,
        LawfulEvil,
        NeutralEvil,
        ChaoticEvil
    }

    #endregion Base Objects

    public class Rat : BaseMonster
    {
        public Rat()
        {
            Name = "Rat";
            Description = "A common rodent found in sewers and dungeons.";
            BaseExperience = 5;
            Level = 1;
            Health = 10;
            Speed = 5;
            Strength = 2;
            Intelligence = 1;
            DefenseType = DefenseType.Light;
            Defense = 1;
            Size = CreatureSize.Tiny;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Common;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class Goblin : BaseMonster
    {
        public Goblin()
        {
            Name = "Goblin";
            Description = "A small and mischievous humanoid creature often found in caves and forests.";
            BaseExperience = 20;
            Level = 3;
            Health = 30;
            Speed = 7;
            Strength = 5;
            Intelligence = 3;
            DefenseType = DefenseType.Light;
            Defense = 2;
            Size = CreatureSize.Small;
            Type = CreatureType.Humanoid;
            Rarity = CreatureRarity.Uncommon;
            Behavior = BehaviorPattern.ChaoticEvil;
            Spells = new List<BaseSpell>();
        }
    }

    public class Skeleton : BaseMonster
    {
        public Skeleton()
        {
            Name = "Skeleton";
            Description = "An animated corpse of a humanoid creature, often found in crypts and graveyards.";
            BaseExperience = 15;
            Level = 2;
            Health = 20;
            Speed = 4;
            Strength = 3;
            Intelligence = 1;
            DefenseType = DefenseType.Mediume;
            Defense = 3;
            Size = CreatureSize.Medium;
            Type = CreatureType.Undead;
            Rarity = CreatureRarity.Common;
            Behavior = BehaviorPattern.NeutralEvil;
            Spells = new List<BaseSpell>();
        }
    }

    public class Zombie : BaseMonster
    {
        public Zombie()
        {
            Name = "Zombie";
            Description = "A reanimated corpse of a humanoid creature, often found in graveyards and dungeons.";
            BaseExperience = 25;
            Level = 4;
            Health = 40;
            Speed = 3;
            Strength = 4;
            Intelligence = 1;
            DefenseType = DefenseType.Heavy;
            Defense = 4;
            Size = CreatureSize.Medium;
            Type = CreatureType.Undead;
            Rarity = CreatureRarity.Uncommon;
            Behavior = BehaviorPattern.NeutralEvil;
            Spells = new List<BaseSpell>();
        }
    }

    public class Snake : BaseMonster
    {
        public Snake()
        {
            Name = "Snake";
            Description = "A venomous reptile often found in jungles and swamps.";
            BaseExperience = 10;
            Level = 2;
            Health = 15;
            Speed = 6;
            Strength = 3;
            Intelligence = 1;
            DefenseType = DefenseType.Light;
            Defense = 1;
            Size = CreatureSize.Small;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Common;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class Wolf : BaseMonster
    {
        public Wolf()
        {
            Name = "Wolf";
            Description = "A wild and aggressive canine often found in forests and mountains.";
            BaseExperience = 30;
            Level = 5;
            Health = 50;
            Speed = 8;
            Strength = 6;
            Intelligence = 2;
            DefenseType = DefenseType.Mediume;
            Defense = 3;
            Size = CreatureSize.Medium;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Uncommon;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }

    }

    public class AlphaWolf : BaseMonster
    {
        public AlphaWolf()
        {
            Name = "Alpha Wolf";
            Description = "The leader of a wolf pack, stronger and more aggressive than regular wolves.";
            BaseExperience = 50;
            Level = 7;
            Health = 80;
            Speed = 10;
            Strength = 8;
            Intelligence = 3;
            DefenseType = DefenseType.Heavy;
            Defense = 5;
            Size = CreatureSize.Large;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Rare;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }

    }

    public class Moskito : BaseMonster
    {
        public Moskito()
        {
            Name = "Moskito";
            Description = "A small flying insect that feeds on blood, often found in swamps and jungles.";
            BaseExperience = 5;
            Level = 1;
            Health = 5;
            Speed = 10;
            Strength = 1;
            Intelligence = 1;
            DefenseType = DefenseType.Nothing;
            Defense = 0;
            Size = CreatureSize.Tiny;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Common;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class SmallSpider : BaseMonster
    {
        public SmallSpider()
        {
            Name = "Small Spider";
            Description = "A small arachnid that can be found in dark and damp places.";
            BaseExperience = 10;
            Level = 2;
            Health = 10;
            Speed = 5;
            Strength = 2;
            Intelligence = 1;
            DefenseType = DefenseType.Light;
            Defense = 1;
            Size = CreatureSize.Tiny;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Common;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class GiantSpider : BaseMonster
    {
        public GiantSpider()
        {
            Name = "Giant Spider";
            Description = "A large and dangerous arachnid that can be found in caves and forests.";
            BaseExperience = 30;
            Level = 5;
            Health = 40;
            Speed = 7;
            Strength = 5;
            Intelligence = 2;
            DefenseType = DefenseType.Mediume;
            Defense = 3;
            Size = CreatureSize.Large;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Uncommon;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class Werewolf : BaseMonster
    {
        public Werewolf()
        {
            Name = "Werewolf";
            Description = "A humanoid creature that can transform into a wolf, often found in forests and mountains.";
            BaseExperience = 100;
            Level = 10;
            Health = 100;
            Speed = 12;
            Strength = 10;
            Intelligence = 5;
            DefenseType = DefenseType.Heavy;
            Defense = 5;
            Size = CreatureSize.Large;
            Type = CreatureType.Humanoid;
            Rarity = CreatureRarity.Rare;
            Behavior = BehaviorPattern.ChaoticEvil;
            Spells = new List<BaseSpell>();
        }
    }

    public class Octopus : BaseMonster
    {
        public Octopus()
        {
            Name = "Octopus";
            Description = "A sea creature with eight arms, often found in oceans and underwater caves.";
            BaseExperience = 20;
            Level = 3;
            Health = 30;
            Speed = 5;
            Strength = 4;
            Intelligence = 3;
            DefenseType = DefenseType.Light;
            Defense = 2;
            Size = CreatureSize.Medium;
            Type = CreatureType.Beast;
            Rarity = CreatureRarity.Uncommon;
            Behavior = BehaviorPattern.ChaoticNeutral;
            Spells = new List<BaseSpell>();
        }
    }

    public class Dragon : BaseMonster
    {
        public Dragon()
        {
            Name = "Dragon";
            Description = "A legendary and powerful creature that can fly and breathe fire, often found in mountains and caves.";
            BaseExperience = 500;
            Level = 20;
            Health = 500;
            Speed = 15;
            Strength = 20;
            Intelligence = 10;
            DefenseType = DefenseType.Heavy;
            Defense = 10;
            Size = CreatureSize.Gargantuan;
            Type = CreatureType.Dragon;
            Rarity = CreatureRarity.Legendary;
            Behavior = BehaviorPattern.ChaoticEvil;
            Spells = new List<BaseSpell>();
        }
    }
}
