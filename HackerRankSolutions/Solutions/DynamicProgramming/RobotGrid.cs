using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.DynamicProgramming
{
    /// <summary>
    /// Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
    /// The robot can only move in two directions, right and down, but certain cells are "off limits" such that
    /// the robot cannot step on them. Design an algorithm to find a path for the robot from the top left to
    /// the bottom right.
    /// </summary>
    public class RobotGrid
    {
        public static IList<Point> GetPath(bool[][] maze)
        {
            if (maze == null || maze.Length == 0)
                return null;

            var failedPoint = new HashSet<Point>();
            IList<Point> path = new List<Point>();
            if (GetPath(maze, maze.Length - 1, maze[0].Length - 1, path, failedPoint))
                return path;
            
            return null;
        }

        private static bool GetPath(bool[][] maze, int row, int col, IList<Point> path, HashSet<Point> failedPoints)
        {
            if (row < 0 || col < 0 || !maze[row][col])
                return false;

            var p = new Point(row, col);

            if (failedPoints.Contains(p))
                return false;
            

            var isAtOrigin = row == 0 && col == 0;
            if (isAtOrigin || GetPath(maze, row , col - 1, path, failedPoints) || GetPath(maze, row - 1, col, path, failedPoints))
            {
                
                path.Add(p);
                return true;
            }

            failedPoints.Add(p);
            return false;
        }
    }
}
