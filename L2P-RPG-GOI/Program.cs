using Discord;
using Discord.Commands;
using Discord.WebSocket;
using L2P_RPG_GOI.Discord.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L2P_RPG_GOI
{
    class Program
    {
        private CommandHandler _commandHandler;
        private DiscordSocketClient _client;


        static string WorldName = "Dagnaros";
        static Player player;
        static Enemy enemy;
        static bool itIsThePlayersTurn;
        static bool playerFlee = false;
        static bool guardMitigated = false;
        public static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            using (var commandService = new CommandService())
            {

                _client.Log += Log;

                //  You can assign your bot token to a string, and pass that in to connect.
                //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
                //var token = "token";

                // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
                var token = Environment.GetEnvironmentVariable("L2PBotToken");
                if (string.IsNullOrWhiteSpace(token))
                    throw new Exception("You don't have a L2PBotToken Environment Variable.");
                // var token = File.ReadAllText("token.txt");
                // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();


                _commandHandler = new CommandHandler(_client, commandService);
                await _commandHandler.InstallCommandsAsync();
                // Block this task until the program is closed.
                await Task.Delay(-1);
            }
        }

        private static void Game()
        {
            //welcome (cool ascii art)
            Welcome();
            //menu
            Menu();
            //create a character
            while (player.CurrentHealth > 0)
                StartFight();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private static void StartFight()
        {
            playerFlee = false;
            Print($"Ready... Fight!");
            enemy = new Enemy(player.Level);
            Print($"A wild {enemy.Type} appears!");
            Print($"Enemy Accuracy-{enemy.Accuracy}%, Strength-{enemy.Strength}, Level-{enemy.Level}, ExperienceAwardedOnDeath-{enemy.ExperienceAwardedOnDeath} ");
            Console.ReadLine();
            itIsThePlayersTurn = false;
            while (player.CurrentHealth > 0 && enemy.CurrentHealth > 0 && !playerFlee)
            {
                if (itIsThePlayersTurn)
                    PlayerTurn();
                else
                    EnemyTurn();

                itIsThePlayersTurn = !itIsThePlayersTurn;
            }
            //check for dead
            if (player.CurrentHealth < 1)
            {
                var deathPhrases = new List<string> { "YOU DIED", "WASTED", "UNINSTALL", "GIT GUD", "ADIOS MUCHACHO", "ZAK SUX NVR 4 GIT" };
                var random = new Random();
                var fucked = deathPhrases[random.Next(0, deathPhrases.Count)];
                Console.ForegroundColor = ConsoleColor.Red;
                Print($"{ fucked }");
                Console.ResetColor();
            }
            if (enemy.CurrentHealth < 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Print($"You killed the { enemy.Type }!  Grats bro!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Print($"You gained {enemy.ExperienceAwardedOnDeath} experience!");
                player.ExperiencePoints = player.ExperiencePoints + enemy.ExperienceAwardedOnDeath;
                Print($"You are level {player.Level} and have {player.ExperiencePoints} experience!");
                Console.ResetColor();
            }
        }

        private static void PlayerTurn()
        {
            Print($"");
            var action = Prompt($"It's your turn!  What would you like to do sir or madam {player.Class.Name}? (1.) (A)ttack, 2.) (G)uard, 3.) (F)lee)", new List<string> { "Attack", "Guard", "Flee", "1", "2", "3", "A", "G", "F" });

            if (action == "F" || action == "Flee" || action == "3")
            {
                var random = new Random();
                var fleeChance = random.Next(0, 99);
                if (fleeChance < 30)
                {
                    playerFlee = true;
                    Print($"You fled cuz you a bitch.");
                }
                else
                    Print("You are a pussy bitch and tried to run.  But you are also a failure.  So you failed to flee you failure pussy bitch.");
            }
            else if (action == "G" || action == "Guard" || action == "2")
            {
                Print($"You guarded!");
                var healedAmount = (player.MaxHealth / 10);
                player.CurrentHealth = player.CurrentHealth + healedAmount;
                if (player.CurrentHealth > player.MaxHealth)
                    player.CurrentHealth = player.MaxHealth;

                Print($"Your healed {healedAmount}.");
                Print($"Your current health is {player.CurrentHealth}.");

                guardMitigated = true;
            }
            else if (action == "A" || action == "Attack" || action == "1")
            {
                //choose attack (based on your attacks available)
                var playerAttackNames = new List<string>();
                for (int i = 0; i < player.Class.Attacks.Count; i++)
                    playerAttackNames.Add(player.Class.Attacks[i].Name);


                var attackChoiceString = Prompt(string.Join(",", playerAttackNames), playerAttackNames);
                //calculate damage based on the attack and some stats related to the player class
                Attack attackChosen = null;
                foreach (var attack in player.Class.Attacks)
                {
                    if (attack.Name == attackChoiceString)
                    {
                        attackChosen = attack;
                        break;
                    }
                }
                int modifier = 0;
                if (player.Class.Name == "Warrior") modifier = player.Strength;
                else if (player.Class.Name == "Archer") modifier = player.Dexterity;
                else if (player.Class.Name == "Mage") modifier = player.Intellect;

                int damage = attackChosen.DoDamage(modifier);


                enemy.CurrentHealth = enemy.CurrentHealth - damage;
                Print($"You hit {enemy.Type} for {damage} damage!");
                Print($"The {enemy.Type}'s current health is {enemy.CurrentHealth}.");
                var random = new Random();
                var stunChance = random.Next(0, 99);
                if (stunChance > 70)
                {
                    Print($"Well Done! The {enemy.Type} is stunned! You have a perfect chance to smack the shit out of it, again!");
                    var roll = Prompt($"Press any key to roll a 20 sided die to determine the damage on the stunned {enemy.Type}.");
                    if (roll != null)
                    {
                        int stunDamage = random.Next(1, 21);
                        enemy.CurrentHealth = enemy.CurrentHealth - stunDamage;
                        Print($"While it was stunned you smacked that {enemy.Type} for {stunDamage} damage!");
                        Print($"The {enemy.Type}'s current health is {enemy.CurrentHealth}.");
                    }
                }
            }
        }

        private static void EnemyTurn()
        {
            Print($"");
            var random = new Random();
            var doesHit = random.Next(0, 100);
            if (doesHit <= enemy.Accuracy)
            {
                //hit player based off enemy strength
                int damage = CalculateDamage(enemy.Strength);
                if (guardMitigated)
                {
                    damage = damage / 2;
                    guardMitigated = false;
                }
                player.CurrentHealth = player.CurrentHealth - damage;
                Print($"{enemy.Type} hit you for {damage} damage!");
                Print($"Your current health is {player.CurrentHealth}.");
            }
            else
                Print("Enemy swang and missed");
        }

        private static int CalculateDamage(int strength)
        {
            var random = new Random();
            var damage = strength / random.Next(8, 13);
            var doesCrit = random.Next(0, 100);
            if (doesCrit < 20)
            {
                damage = damage * 2;
                Print($"Critical hit!");
            }

            return damage;
        }

        private static void Welcome()
        {
            Print("Welcome to the game bitch.");
            Print("/////////*******//////////");
            Print("///////attempted//////////");
            Print("/////cool ascii art///////");
            Print("/////////*here**//////////");
            Print("/////////*-----*//////////");
            Print("/////////*******//////////");
        }

        private static void Menu()
        {
            var playerName = Prompt("What is your name?");
            var playerClass = Prompt("What class are you? (Warrior, Archer, Mage)", new List<string> { "Warrior", "Archer", "Mage" });
            Print("");

            player = new Player(playerName, playerClass);

            Print($"Welcome to {WorldName} fellow {player.Name}");
            Print($"We have not had a {player.Class.Name} at {WorldName} since the year 2019. Before the storm...of covid");
            Print($"Oh MY!  Look at how strong you are! ******** Strength: {player.Strength}.");
            Print($"Little dexterious dick bro are you! ******** Dexterity: {player.Dexterity}.");
            Print($"You are sooooo smart!........       ******** Intellect: {player.Intellect}.");

            Print("");
            Print($"Congratulations.  You have created your character.  Enjoy the world of {WorldName}.");
            Print($"Health: {player.MaxHealth}, Experience: {player.ExperiencePoints}, Level: {player.Level}");
        }

        private static string Prompt(string promptThis)
        {
            string input = "";
            //check to see if they put anything in
            while (input.Trim().Length <= 0)
            {
                //tell them to put something in.
                Print(promptThis);
                //let them input something
                input = Console.ReadLine();
            }
            //return the something
            return input;
        }

        private static string Prompt(string promptThis, List<string> expectedResponses)
        {
            var input = Prompt(promptThis);

            while (!expectedResponses.Contains(input))
            {
                input = Prompt($"Choose from: {string.Join(",", expectedResponses)}");
            }
            return input;
        }

        private static void Print(string line)
        {
            Console.WriteLine(line);
        }
    }
}
