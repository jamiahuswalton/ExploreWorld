using System;

namespace ExploreWorld
{
    class Program
    {
        static int currRow = 0;
        static int currCol = 0;
        const int rowSize = 4;
        const int colSize = 4;

        public static void Move(Tile[,] tileGrid, string direction)
        {
            int row = currRow;
            int col = currCol;

            // figure out the direction we want to move in
            if (direction.ToLower().Equals("w"))
            {
                row--;
            }
            else if (direction.ToLower().Equals("a"))
            {
                col--;
            }
            else if (direction.ToLower().Equals("s"))
            {
                row++;
            }
            else if (direction.ToLower().Equals("d"))
            {
                col++;
            }
            else
            {
                Console.WriteLine("Use w, s, a or d to move or x to exit noob!\n");
            }

            // complete the move
            if (row < rowSize && row >= 0 && col < colSize && col >= 0)
            {
                if (IsObstacleInWay(tileGrid, row, col))
                {
                    Console.WriteLine("There is something in your way so you cannot move there.\n");
                }
                else
                {
                    currRow = row;
                    currCol = col;
                }
            }
            else
            {
                Console.WriteLine("We don't want you to leave our beautiful world, so you cannot go that way.\n");
            }
        }

        private static void EvaluateTile(Tile[,] tileGrid, int playerCurrentRow, int playerCurrentCol, Character myCharacter)
        {
            //Check the tile type
            Tile.TerrainTypes currentTileType = tileGrid[playerCurrentRow, playerCurrentCol].getTerrain();
            int currentHealthModifer = tileGrid[playerCurrentRow, playerCurrentCol].getHealthModifer();

            //Update health if needed
            if (currentTileType == Tile.TerrainTypes.Fire)
            {
                myCharacter.UpdatePlayerHealth(currentHealthModifer);
            }
        }

        // format of method: [scope of function] [static if not being called on class object] [value type of what is being returned]
        // [name] (list of parameters)
        private static bool IsObstacleInWay(Tile[,] tileGrid, int row, int col)
        {
            return !tileGrid[row, col].getIsPassable();// If it is passable then that means that it is not an obstacle
        }

        public static void PrintGameBoard(Tile[,] tileGrid, int currRow, int currCol)
        {
            for (int i = 0; i < rowSize; i++) // Pick the row
            {
                for (int j = 0; j < colSize; j++) //Pick the column
                {
                    if (i == currRow && j == currCol)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Tile.TerrainTypes currentTerrain = tileGrid[i, j].getTerrain();
                        if (currentTerrain == Tile.TerrainTypes.Water)
                        {
                            Console.Write("W");
                        } 
                        else if (currentTerrain == Tile.TerrainTypes.Fire)
                        {
                            //Print Fire to console
                            Console.Write("F");
                        }
                        else if (currentTerrain == Tile.TerrainTypes.Rock)
                        {
                            //Print Rock
                            Console.Write("R");
                        }
                        else if (currentTerrain == Tile.TerrainTypes.Grass)
                        {
                            //Print grass
                            Console.Write("G");
                        }
                        else
                        {
                            Console.Write("Fail");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Character JayW = new Character("Jay", 100, false, true, true, 100, 1);
            //Character person = new Character(100, "Bob", false, true, true, 20, 1);

            //Need to create 16 tiles (4 X 4)

            //Tile types
            Tile waterTile = new Tile(Tile.TerrainTypes.Water, 0.75f, 0, true);
            Tile fireTile = new Tile(Tile.TerrainTypes.Fire, 1.0f, -3, true);
            Tile grassTile = new Tile(Tile.TerrainTypes.Grass, 1.0f, 0, true);
            Tile rockTile = new Tile(Tile.TerrainTypes.Rock, .80f, 0, false);

            //World tile grid
            Tile[,] tileGrid = new Tile[rowSize, colSize]
            {
                {waterTile, grassTile, rockTile, fireTile},
                {grassTile, fireTile, waterTile, rockTile},
                {fireTile, rockTile, grassTile, waterTile },
                {rockTile, waterTile, fireTile, grassTile },
            };

            /*
            int[,] tileGrid = new int[rowSize, colSize]
                                    {{0, 0, 1, 0},
                                {1, 0, 0, 0},
                                {0, 0, 0, 1},
                                {0, 1, 0, 0}};
            */

            Console.WriteLine("Welcome to the Explore the World game! You are tasked with exploring the map, " +
                "finding the axe and cutting down the tree.\nUse w, s, a and d to move around and x to exit the game.  Enjoy!\n");

            // loop for continual movement
            while (JayW.getHealth() > 0)
            {
                Console.WriteLine("Where do you want to go traveler? The X represents where you are now.\n");
                // printing out game board
                PrintGameBoard(tileGrid, currRow, currCol);

                // reading direction from user input
                string direction = Console.ReadLine();

                // check if user wants to exit the game
                if (direction.ToLower() == "x")
                {
                    Console.WriteLine("Thank you for joining the journey!\n");
                    break;
                }

                Move(tileGrid, direction);
                EvaluateTile(tileGrid, currRow, currCol, JayW);
                Console.WriteLine("Health: " + JayW.getHealth().ToString());
            }

            Console.WriteLine("Game Over!");

            //Ask the player if they want to play again


        }
    }
}
