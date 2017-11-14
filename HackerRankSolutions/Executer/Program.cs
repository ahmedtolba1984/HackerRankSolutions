using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Solutions.DynamicProgramming;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            bool[][] maze = AssortedMethods.RandomBooleanMatrix(size, size, 70);

            AssortedMethods.PrintMatrix(maze);

            IList<Point> path = RobotGrid.GetPath(maze);
            Console.WriteLine(path?.ToString() ?? "No path found.");

            Console.ReadKey();
        }
    }
}
