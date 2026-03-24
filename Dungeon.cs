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
    }

    public class  DungeonWayPoint
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsStart { get; set; }
        public bool IsEndpoint { get; set; }
        public List<DungeonWayPoint> ConnectedWayPoints { get; set; } = new List<DungeonWayPoint>();
        public List<DungeonEnvent> Events { get; set; } = new List<DungeonEnvent>();

        public void EnterWayPoint()
        {
            Console.WriteLine($"Entering waypoint: {Name} - {Description}");
            foreach (var dungeonEvent in Events)
            {
                dungeonEvent.TriggerEvent();
            }
        }
    }

    public class DungeonMap
    {
        public Dungeon Dungeon { get; set; }
        public List<DungeonWayPoint> WayPoints { get; set; } = new List<DungeonWayPoint>();
    }

    public class DungeonEnvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Options { get; set; }
        public void TriggerEvent()
        {
            Console.WriteLine($"Event triggered: {Name} - {Description}");
        }
    }

    public static class DungeonFactory
    {
        public static Dungeon CreateStartingDungeon()
        {
            var dungeon = new Dungeon();
            dungeon.Name = "The Forgotten Cave";
            dungeon.Difficulty = 1;
            dungeon.Description = "Start your adventure in this mysterious cave filled with hidden treasures and lurking dangers.";
            
            var firstWayPoint = new DungeonWayPoint
            {
                Name = "Entrance",
                Description = "The dark and eerie entrance of the cave.",
                IsStart = true
            };

            var starsEvent = new DungeonEnvent
            {
                Id = 1,
                Name = "Start of the journey",
                Description = "You see dark cave and three ways at front. What will you do?"
            };
        }
    }

    public class DungeonManager
    {
        public List<Dungeon> Dungeons { get; set; } = new List<Dungeon>();
        public List<DungeonMap> DungeonMaps { get; set; } = new List<DungeonMap>();
        public void AddDungeon(Dungeon dungeon)
        {
            Dungeons.Add(dungeon);
            Console.WriteLine($"Dungeon added: {dungeon.Name} with difficulty {dungeon.Difficulty}");
        }
        public void AddDungeonMap(DungeonMap dungeonMap)
        {
            DungeonMaps.Add(dungeonMap);
            Console.WriteLine($"Dungeon map added for dungeon: {dungeonMap.Dungeon.Name}");
        }
    }
}
