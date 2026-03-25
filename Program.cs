using MyCoolGame;

var gameEngine = new GameEngine();
gameEngine.Run();

var firstDungeon = new Dungeon
{
    Name = "Начальное подземелье",
    Difficulty = 1,
    Description = "Сдесь начинается ваш путь. Удачи!",
    Start = new DungeonNode
    {
        NodeDescription = "Вы видете перед собой длинный мрачный коридор.",
        IsCurrent = true,
    }
};
var startNode = new DungeonNode
{
    NodeDescription = "Перед вами развилка. Справа узкий темный проход кишаший голодынми крысами, слева подозрительно безжиненный коридор. Куда вы пойдете?",
    Dungeon = firstDungeon
};

var rightNode = new DungeonNode
{
    NodeDescription = "Вы пошли по правому коридору и наткнулись на стаю голодных крыс. Они набросились на вас и откусили вам ногу. Вы проиграли.",
    Dungeon = firstDungeon
};

var leftNode = new DungeonNode
{
    NodeDescription = "Вы пошли по левому коридору и нашли сундук с сокровищами. Вы выиграли!",
    Dungeon = firstDungeon
};