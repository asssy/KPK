using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesGame
{
	public class Mine
	{
		public class PlayerScore
		{
			string name;
			int score;

			public string Name
			{
				get 
                { 
                    return name; 
                }
				set 
                {
                    name = value; 
                }
			}

			public int Score
			{
				get 
                { 
                    return score; 
                }
                set 
                { 
                    score = value; 
                }
			}

			public PlayerScore() { }

            public PlayerScore(string name, int score)
			{
                this.name = name;
                this.score = score;
			}
		}

		static void Main()
		{
            const int MAX = 35;

			string command = string.Empty;
			char[,] playGround = CreatePlayGround();
			char[,] bombs = PutBombs();
			int count = 0;
            bool exploaded = false;
            bool startToPlay = true;
            bool winGame = false;

            int row = 0;
            int col = 0;

            List<PlayerScore> champions = new List<PlayerScore>(6);

			do
			{
                if (startToPlay)
				{
					Console.WriteLine("Start to play Mines Game" +
                    " Command 'top' shows Scores, 'restart' start new game, 'exit' escape to game!");
                    PrintGround(playGround);
                    startToPlay = false;
				}

				Console.Write("Please enter row and col: ");

				command = Console.ReadLine().Trim();

                if (command.Length >= 3)
				{
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= playGround.GetLength(0) && col <= playGround.GetLength(1))
					{
                        command = "turn";
					}

				}

                switch (command)
				{
					case "top":
                        Scores(champions);
						break;
					case "restart":
                        playGround = CreatePlayGround();
                        bombs = PutBombs();
                        PrintGround(playGround);
						exploaded = false;
                        startToPlay = false;
						break;
					case "exit":
						Console.WriteLine("Bye bye!");
						break;
					case "turn":
                        if (bombs[row, col] != '*')
						{
                            if (bombs[row, col] == '-')
							{
                                tisinahod(playGround, bombs, row, col);
                                count++;
							}

                            if (MAX == count)
							{
                                winGame = true;
							}
							else
							{
                                PrintGround(playGround);
							}

						}
						else
						{
                            exploaded = true;
						}

						break;

					default:
						Console.WriteLine("\nInvalid command!\n");
						break;
				}

                if (exploaded)
				{
                    PrintGround(bombs);

					Console.Write("\nSorry! Your game is finished with {0} points. " +
                        "Please enter your nickname: ", count);

                    string nickname = Console.ReadLine();

                    PlayerScore theScore = new PlayerScore(nickname, count);

                    if (champions.Count < 5)
					{
                        champions.Add(theScore);
					}
					else
					{
                        for (int i = 0; i < champions.Count; i++)
						{
                            if (champions[i].Score < theScore.Score)
							{
                                champions.Insert(i, theScore);
                                champions.RemoveAt(champions.Count - 1);
								break;
							}

						}
					}

                    champions.Sort((PlayerScore r1, PlayerScore r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((PlayerScore r1, PlayerScore r2) => r2.Score.CompareTo(r1.Score));
                    Scores(champions);

                    playGround = CreatePlayGround();
                    bombs = PutBombs();
					count = 0;
                    exploaded = false;
                    startToPlay = true;
				}
                if (winGame)
				{
					Console.WriteLine("\nCongratiuraltions! You open 35 cells.");

                    PrintGround(bombs);

					Console.WriteLine("Please enter your name: ");

					string name = Console.ReadLine();
                    PlayerScore points = new PlayerScore(name, count);
                    champions.Add(points);
                    Scores(champions);
					playGround = CreatePlayGround();
                    bombs = PutBombs();
					count = 0;
                    winGame = false;
                    startToPlay = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria!");
			Console.WriteLine("Bye bye.");
			Console.Read();
		}

        private static void Scores(List<PlayerScore> points)
		{
			Console.WriteLine("\nScore:");
			if (points.Count > 0)
			{
                for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells",
                        i + 1, points[i].Name, points[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void tisinahod(char[,] playGround,
            char[,] bombs, int row, int col)
		{
            char numberOfBombs = kolko(bombs, row, col);
            bombs[row, col] = numberOfBombs;
            playGround[row, col] = numberOfBombs;
		}

		private static void PrintGround(char[,] ground)
		{
            int rows = ground.GetLength(0);
            int cols = ground.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
				{
                    Console.Write(string.Format("{0} ", ground[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

        private static char[,] CreatePlayGround()
		{
			int groundRows = 5;
			int groundCols = 10;
            char[,] ground = new char[groundRows, groundCols];
            for (int i = 0; i < groundRows; i++)
			{
                for (int j = 0; j < groundCols; j++)
				{
                    ground[i, j] = '?';
				}
			}

            return ground;
		}

        private static char[,] PutBombs()
		{
			int rows = 5;
            int cols = 10;
            char[,] playGround = new char[rows, cols];

            for (int i = 0; i < rows; i++)
			{
                for (int j = 0; j < cols; j++)
				{
                    playGround[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int col = (i2 / cols);
				int row = (i2 % cols);
                if (row == 0 && i2 != 0)
				{
                    col--;
                    row = cols;
				}
				else
				{
                    row++;
				}

                playGround[col, row - 1] = '*';
			}

            return playGround;
		}

		private static void smetki(char[,] playGround)
		{
            int col = playGround.GetLength(0);
            int row = playGround.GetLength(1);

            for (int i = 0; i < col; i++)
			{
                for (int j = 0; j < row; j++)
				{
                    if (playGround[i, j] != '*')
					{
						char kolkoo = kolko(playGround, i, j);
                        playGround[i, j] = kolkoo;
					}
				}
			}
		}

		private static char CalculateBombs(char[,] side, int row, int col)
		{
			int count = 0;
            int rows = side.GetLength(0);
            int cols = side.GetLength(1);

			if (row - 1 >= 0)
			{
                if (side[row - 1, col] == '*')
				{
                    count++; 
				}
			}
            if (row + 1 < rows)
			{
                if (side[row + 1, col] == '*')
				{
                    count++; 
				}
			}
            if (col - 1 >= 0)
			{
                if (side[row, col - 1] == '*')
				{
                    count++;
				}
			}
            if (col + 1 < cols)
			{
                if (side[row, col + 1] == '*')
				{
                    count++;
				}
			}
            if ((row - 1 >= 0) && (col - 1 >= 0))
			{
                if (side[row - 1, col - 1] == '*')
				{
                    count++; 
				}
			}
            if ((row - 1 >= 0) && (col + 1 < cols))
			{
                if (side[row - 1, col + 1] == '*')
				{
                    count++; 
				}
			}
            if ((row + 1 < rows) && (col - 1 >= 0))
			{
                if (side[row + 1, col - 1] == '*')
				{
                    count++; 
				}
			}
            if ((row + 1 < rows) && (col + 1 < cols))
			{
                if (side[row + 1, col + 1] == '*')
				{ 
					count++; 
				}
			}
            return char.Parse(count.ToString());
		}
	}
}
