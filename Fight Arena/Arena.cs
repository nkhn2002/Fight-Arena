using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fight_Arena
{
    class Arena
    {
        // First 4 arenas
        public static List<Hero> Arena1 = new List<Hero>();
        public static List<Hero> Arena2 = new List<Hero>();
        public static List<Hero> Arena3 = new List<Hero>();
        public static List<Hero> Arena4 = new List<Hero>();

        // 2 Arenas for final battle
        public static List<Hero> Arena5 = new List<Hero>();
        public static List<Hero> Arena6 = new List<Hero>();

        // Final battle
        public static List<Hero> Arena7 = new List<Hero>();

        // Random object, for different attack and defence ranges.
        public static Random r = new Random();

        public static Attack attack = new Attack();
        public static Defence defence = new Defence();

        // Heroes
        public static Hero h1 { get; set; }
        public static Hero h2 { get; set; }

        public int attackH1 { get; set; }
        public int attackH2 { get; set; }
        public int defenceH1 { get; set; }
        public int defenceH2 { get; set; }

        public int defencePercent { get; set; }
        public int attackPercent { get; set; }
        public int defAtt { get; set; }


        public Arena()
        {

        }

        public void Fight(Hero h1, Hero h2)
        {
            // Use this for adding the hero winner to next arena
            Hero h1Next = h1;
            Hero h2Next = h2;

            while (true)
            {
                // Write arena and hero information
                Console.WriteLine($"=================== ARENA {Program.ArenaNum} ===================");
                Console.WriteLine("Hero 1:\t\t \t\tHero 2:");
                Console.WriteLine($"{h1.Name}\t\t\t{h2.Name}");
                Console.WriteLine($"{h1.Hitpoint}\t\t\t\t{h2.Hitpoint}\n");

                switch (h1.Name)
                {
                    case "Kung Fu Harry":
                        // Attack
                        attackH1 = attack.GetRange(new Attack(2));
                        // Defence
                        defenceH1 = defence.GetRange(new Defence(5));
                        break;

                    case "Superhunden dino":
                        // Attack
                        attackH1 = attack.GetRange(new Attack(r.Next(6, 9)));
                        // Defence
                        defenceH1 = defence.GetRange(new Defence(r.Next(2, 9)));
                        break;

                    case "Minimusen Mikkel":
                        // Attack
                        attackH1 = attack.GetRange(new Attack(9));
                        // Defence
                        defenceH1 = defence.GetRange(new Defence(9));
                        break;

                    case "Gummigeden Ivan":
                        // Attack
                        attackH1 = attack.GetRange(new Attack(6));
                        // Defence
                        defenceH1 = defence.GetRange(new Defence(8));
                        break;
                }

                switch (h2.Name)
                {
                    case "Hurtig Karl":
                        // Defence
                        defenceH2 = defence.GetRange(new Defence(3));

                        // 50-50 to get right or left hand
                        attackPercent = r.Next(1, 101);
                        if (attackPercent <= 50) { attackH2 = attack.GetRange(new Attack(2)); }
                        else if (attackPercent > 49) { attackH2 = attack.GetRange(new Attack(5)); }
                        break;

                    case "Gift Gunner":
                        // Defence
                        defenceH2 = defence.GetRange(new Defence(5));
                        // Attack
                        attackH2 = attack.GetRange(new Attack(r.Next(1, 14)));
                        break;

                    case "Katten Tiger":
                        // Defence
                        defenceH2 = defence.GetRange(new Defence(4));
                        // Attack
                        attackH2 = attack.GetRange(new Attack(r.Next(3, 7)));
                        break;

                    case "Elgen Egon":
                        // Defence
                        defenceH2 = defence.GetRange(new Defence(4));
                        // Attack
                        attackH2 = attack.GetRange(new Attack(r.Next(1, 16)));
                        break;
                }

                /* HERO 1 ATTACK */
                Console.WriteLine($"{h1.Name} used {attackH1} attack!");

                // If defence percent is less than 30 the defence automatically sets to 0 (I use this because I couldn't figure out how else to make it work)
                defencePercent = r.Next(0, 101);
                if (defencePercent < 30) { defenceH2 = 0; }

                // Adjust Hero 1 hitpoints
                if (attackH1 - defenceH2 > 0) { h2.Hitpoint = h2.Hitpoint - (attackH1 - defenceH2); }

                Console.WriteLine($"{h2.Name} used {defenceH2} defence!\n");

                /* HERO 2 ATTACK */
                Console.WriteLine($"{h2.Name} used {attackH2} attack!");

                if(h2.Name == "Katten Tiger")
                {
                    h2.Hitpoint = h2.Hitpoint + 3;
                }

                // If defence percent is less than 30 the defence automatically sets to 0 (I use this because I couldn't figure out how else to make it work)
                defencePercent = r.Next(0, 101);
                if (defencePercent < 30) { defenceH1 = 0; }

                // Adjust Hero 2 hitpoints
                if (attackH2 - defenceH1 > 0) { h1.Hitpoint = h1.Hitpoint - (attackH2 - defenceH1); }

                Console.WriteLine($"{h1.Name} used {defenceH1} defence!");

                // I didn't know how else to make this work, but it works.
                // What this code does is that it adds a hero to another Arena if that hero won the fight
                // I didn't think I should add comments to each if statement, cause it does the same on each statement ^ (Explaned it at the comment over this one)
                if (Program.ArenaNum == 1 && h1.Hitpoint <= 0)
                {
                    Arena5.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 1 && h2.Hitpoint <= 0)
                {
                    Arena5.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 2 && h1.Hitpoint <= 0)
                {
                    Arena5.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 2 && h2.Hitpoint <= 0)
                {
                    Arena5.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 3 && h1.Hitpoint <= 0)
                {
                    Arena6.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 3 && h2.Hitpoint <= 0)
                {
                    Arena6.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 4 && h1.Hitpoint <= 0)
                {
                    Arena6.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 4 && h2.Hitpoint <= 0)
                {
                    Arena6.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 5 && h1.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 5 && h2.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 6 && h1.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 6 && h2.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the fight!{Color.Reset}");
                    Thread.Sleep(3000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 7 && h1.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h2Next.Name, h2Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h2.Name} won the arena fight!{Color.Reset}");
                    Thread.Sleep(5000);
                    Program.ArenaNum++;
                    break;
                }

                if (Program.ArenaNum == 7 && h2.Hitpoint <= 0)
                {
                    Arena7.Add(new Hero(h1Next.Name, h1Next.Hitpoint));
                    Console.WriteLine($"\n{Color.Green}{h1.Name} won the arena fight!{Color.Reset}");
                    Thread.Sleep(5000);
                    Program.ArenaNum++;
                    break;
                }

                Thread.Sleep(800);

                // Console.ReadLine();
                Console.Clear();
            }
        }

        public void StartFight(int ArenaNum)
        {
            switch (ArenaNum)
            {
                // Start Arena 1
                case 1:
                    h1 = Arena1[0];
                    h2 = Arena1[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 2
                case 2:
                    h1 = Arena2[0];
                    h2 = Arena2[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 3
                case 3:
                    h1 = Arena3[0];
                    h2 = Arena3[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 4
                case 4:
                    h1 = Arena4[0];
                    h2 = Arena4[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 5
                case 5:
                    h1 = Arena5[0];
                    h2 = Arena5[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 6
                case 6:
                    h1 = Arena6[0];
                    h2 = Arena6[1];
                    Fight(h1, h2);
                    break;

                // Start Arena 7
                case 7:
                    h1 = Arena7[0];
                    h2 = Arena7[1];
                    Fight(h1, h2);
                    break;
            }
        }

        public void StartArena()
        {
            // Add heroes to the Arena
            Arena1.Add(new Hero("Kung Fu Harry", 120));
            Arena1.Add(new Hero("Hurtig Karl", 90));

            Arena2.Add(new Hero("Superhunden Dino", 70));
            Arena2.Add(new Hero("Gift Gunner", 90));

            Arena3.Add(new Hero("Minimusen Mikkel", 40));
            Arena3.Add(new Hero("Katten Tiger", 35));

            Arena4.Add(new Hero("Gummigeden Ivan", 70));
            Arena4.Add(new Hero("Elgen Egon", 90));
        }
    }
}
