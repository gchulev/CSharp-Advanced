using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    internal class Program
    {
        static void Main()
        {
            var whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var locations = new Dictionary<string, int>()
            {
                {"Sink", 0 },
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0},
                {"Floor", 0 }
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhiteTile = whiteTiles.Peek();
                int currentGreyTile = greyTiles.Peek();

                if (currentGreyTile == currentWhiteTile)
                {
                    int newLargerTile = currentGreyTile + currentWhiteTile;

                    greyTiles.Dequeue();
                    whiteTiles.Pop();

                    switch (newLargerTile)
                    {
                        case 40:
                            locations["Sink"]++; //sink
                            break;
                        case 50:
                            locations["Oven"]++; //oven
                            break;
                        case 60:
                            locations["Countertop"]++; //countertop
                            break;
                        case 70:
                            locations["Wall"]++; //wall
                            break;
                        default:
                            locations["Floor"]++; //floor
                            break;
                    }
                }
                else
                {
                    whiteTiles.Pop();
                    whiteTiles.Push(currentWhiteTile / 2);

                    greyTiles.Dequeue();
                    greyTiles.Enqueue(currentGreyTile);
                }

            }
            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            var orderedLocations = locations.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            foreach (var item in orderedLocations)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
