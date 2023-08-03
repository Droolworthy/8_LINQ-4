using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ4
{
    internal class Program
    {
        static void Main()
        {
           Database database = new Database();

           database.Work();
        }
    }

    class Database
    {
        private readonly List<Player> _players = new List<Player>();  

        public Database()
        {
            AddPlayers();
        }

        public void Work()
        {
            bool isWork = true;

            int numberPlayers = 3;

            string commandShowTopPowerPlayers = "1";
            string commandShowTopLevelPlayers = "2";
            string commandExit = "3";

            Console.WriteLine("ТОП 3 ПО СИЛЕ - " + commandShowTopPowerPlayers);
            Console.WriteLine("ТОП 3 ПО УРОВНЮ - " + commandShowTopLevelPlayers);
            Console.WriteLine("ВЫХОД - " + commandExit);

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    if (userInput == commandShowTopPowerPlayers)
                    {
                        Console.WriteLine("Топ 3 игрока по силе: ");

                        var filteredPlayers = _players.OrderByDescending(player => player.Power).ToList().Take(numberPlayers);

                        ShowFilteredPlayers(filteredPlayers);
                    }
                    else if (userInput == commandShowTopLevelPlayers)
                    {
                        Console.WriteLine("Топ 3 игрока по уровню: ");

                        var filteredPlayers = _players.OrderByDescending(player => player.Level).ToList().Take(numberPlayers);

                        ShowFilteredPlayers(filteredPlayers);
                    }
                    else if (userInput == commandExit)
                    {
                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                    }
                }
            }
        }

        private void AddPlayers()
        {
            _players.Add(new Player("Владимир", 1, 5));
            _players.Add(new Player("Николай", 2, 30));
            _players.Add(new Player("Анна", 6, 20));
            _players.Add(new Player("Никита", 9, 69));
            _players.Add(new Player("Алиса", 15, 151));
            _players.Add(new Player("Алёна", 22, 9));
            _players.Add(new Player("Илья", 21, 1));
            _players.Add(new Player("Михаил", 52, 123));
            _players.Add(new Player("Кристина", 12, 109));
            _players.Add(new Player("Галина", 11, 421));
        }

        private void ShowFilteredPlayers(IEnumerable<Player> filteredPatients)
        {
            foreach (var patient in filteredPatients)
            {
                Console.WriteLine($"Имя - {patient.Name}, Уровень - {patient.Level}, Сила - {patient.Power}");
            }
        }
    }

    class Player
    {
        public Player(string appellation, int standard, int force)
        {
            Name = appellation;
            Level = standard;
            Power = force;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
    }
}
