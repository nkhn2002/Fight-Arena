using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_Arena
{
    class Program
    {
        public static int ArenaNum { get; set; }
        static void Main(string[] args)
        {
            // Initialize Arena Object
            Arena arena = new Arena();

            // Add heroes to arena
            arena.StartArena();

            // Set the starting arena number
            ArenaNum = 1;

            // loop variable
            bool loop = true;

            while (loop)
            {
                // Start Arena fights with Arena number
                switch (ArenaNum)
                {
                    case 1:
                        arena.StartFight(ArenaNum);
                        break;

                    case 2:
                        arena.StartFight(ArenaNum);
                        break;

                    case 3:
                        arena.StartFight(ArenaNum);
                        break;

                    case 4:
                        arena.StartFight(ArenaNum);
                        break;

                    case 5:
                        arena.StartFight(ArenaNum);
                        break;

                    case 6:
                        arena.StartFight(ArenaNum);
                        break;

                    case 7:
                        arena.StartFight(ArenaNum);
                        break;

                    case 8:
                        loop = false;
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
