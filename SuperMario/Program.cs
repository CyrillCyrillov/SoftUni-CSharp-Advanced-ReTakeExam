using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int size = int.Parse(Console.ReadLine());

            char[,] maze;

            bool isSavePrincess = false;

            int[] positionMario = new int[2] { -1, -1 };
            int[] positionPrincess = new int[2] { -1, -1 };

            string nextLine = Console.ReadLine();

            int columnSize = nextLine.Length;

            maze = new char[size, columnSize];

            for (int i = 0; i < size; i++)
            {
                if(i != 0 )
                {
                    nextLine = Console.ReadLine();
                }

                for (int j = 0; j < size; j++)
                {
                    char nextFieldElement = nextLine[j];

                    if(nextFieldElement == 'M')
                    {
                        positionMario[0] = i; // ROW
                        positionMario[1] = j; // COLUMN

                    }

                    if (nextFieldElement == 'P')
                    {
                        positionPrincess[0] = i; // ROW
                        positionPrincess[1] = j; // COLUMN

                    }
                    maze[i, j] = nextFieldElement;
                }

                
            }

            while (true)
            {
                string[] nextComands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string direction = nextComands[0];
                int newBowserRow = int.Parse(nextComands[1]);
                int newBowserColumn = int.Parse(nextComands[2]);

                maze[newBowserRow, newBowserColumn] = 'B';

                lives--;
                maze[positionMario[0], positionMario[1]] = '-'; // Mario Start Move


                //It can be "W" (up), "S" (down), "A" (left), "D" (right).

                switch (direction.ToUpper())
                {
                    case "W":
                        positionMario[0]--;
                        if(positionMario[0] < 0)
                        {
                            positionMario[0]++;
                        }
                        break;

                    case "S":
                        positionMario[0]++;
                        if (positionMario[0] > size -1)
                        {
                            positionMario[0]--;
                        }
                        break;

                    case "A":
                        positionMario[1]--;
                        if (positionMario[1] < 0)
                        {
                            positionMario[1]++;
                        }
                        break;

                    case "D":
                        positionMario[1]++;
                        if (positionMario[1] > columnSize - 1)
                        {
                            positionMario[1]--;
                        }
                        break;
                }

                if (maze[positionMario[0], positionMario[1]] == 'B')
                {
                    lives -= 2;
                    if(lives > 0)
                    {
                        maze[positionMario[0], positionMario[1]] = '-';
                    }
                }

                if (maze[positionMario[0], positionMario[1]] == 'P' && lives >= 0)
                {
                    isSavePrincess = true;
                    maze[positionMario[0], positionMario[1]] = '-';

                    break; // Mario Is Death And BUT Save The Princess
                }
                
                if (lives <= 0)
                {
                    maze[positionMario[0], positionMario[1]] = 'X';

                    break; // Mario Is Death And NOT Save The Princess
                }

            }

            if(isSavePrincess)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {positionMario[0]};{positionMario[1]}.");
            }

            // print field

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(maze[i, j]);
                }

                Console.WriteLine();
            }

            //Console.WriteLine(positionMario[0]);
            //Console.WriteLine(positionMario[1]);




            //Console.WriteLine("Hello World!");
        }
    }
}
