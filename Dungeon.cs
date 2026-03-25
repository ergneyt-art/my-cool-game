using System;
using System.Collections.Generic;
using System.Text;

namespace MyCoolGame
{
    public class Dungeon
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public DungeonNode Start { get; set; }
        public List<DungeonNode> Nodes { get; set; }
    }

    public class DungeonNode : IDungeonEvent
    {
        public Dungeon Dungeon { get; set; }
        public List<DungeonNode> ConnectedDungeons { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsVisited { get; set; }
        public bool IsFinal { get; set; }
        public DungeonNode PrevDungeonNode { get; set; }
        public Event NodeEvent { get; set; }
        public DungeonNode()
        {
            ConnectedDungeons = new List<DungeonNode>();
        }

        public DungeonNode(DungeonNode prevNode)
        {
            PrevDungeonNode = prevNode;
            ConnectedDungeons = new List<DungeonNode>();
        }

        public void ShowConnectedDungeons()
        {
            Console.WriteLine("Connected Dungeons:");
            foreach (var dungeon in ConnectedDungeons)
            {
                Console.WriteLine("- " + dungeon.Name);
            }
        }

        public bool TriggerEvent(BaseCharacter character)
        {
            Console.WriteLine(NodeEvent.Description);
            var modification = 0;
            if (NodeEvent.IntelligentCost != 0)
            {
                modification += character.Intelligence - NodeEvent.IntelligentCost;
            }

            if (NodeEvent.StrengthCost != 0)
            {
                modification += character.Strength - NodeEvent.StrengthCost;
            }

            if (NodeEvent.AgilityCost != 0)
            {
                modification += character.Agility - NodeEvent.AgilityCost;
            }

            if (NodeEvent.PerceptionCost != 0)
            {
                modification += character.Perception - NodeEvent.PerceptionCost;
            }

            var chance = NodeEvent.BaseChance + modification;
            var randomChance = new Random().Next(0, 100);

            if (chance >= randomChance) 
            {
                Console.WriteLine(NodeEvent.SuccessOutcome);
                return true;
            }
            else
            {
                Console.WriteLine(NodeEvent.FailureOutcome);
                if (NodeEvent.Damage != 0)
                {
                    character.Health -= NodeEvent.Damage;
                }
                return false;
            }
        }

        public void GetResults(BaseCharacter character)
        {
            // Implement result logic here
        }
    }


    public interface IDungeonEvent
    {
        public bool TriggerEvent(BaseCharacter character);

        public void GetResults(BaseCharacter character);
    }

    public class Event
    {
        public EventType Type { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SuccessOutcome { get; set; }
        public string FailureOutcome { get; set; }
        public int IntelligentCost { get; set; }
        public int StrengthCost { get; set; }
        public int AgilityCost { get; set; }
        public int PerceptionCost { get; set; }
        public int BaseChance { get; set; } = 50;

        public int Damage { get; set; }
    }

    public class BattleEvent : Event
    {
        public string EnemyName { get; set; }
        public int EnemyStrength { get; set; }
    }

    public class PuzzleEvent : Event
    {
        public string PuzzleDescription { get; set; }
        public int DifficultyLevel { get; set; }
    }

    public enum EventType
    {
        Combat,
        Puzzle,
        Treasure,
        Trap,
        Boss
    }

}
