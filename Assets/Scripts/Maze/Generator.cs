using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] 
    private int Width = 10;
    [SerializeField] 
    private int Height = 10;

    public Maze GenerateMaze(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        MazeCell[,] cells = new MazeCell[Width, Height];

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeCell { X = x, Y = y };
            }
        }
        removeWalls(cells);

        Maze maze = new Maze();
        maze.cells = cells;

        return maze;
    }

    private void removeWalls(MazeCell[,] maze)
    {
        MazeCell current = maze[0, 0];
        current.Visited = true;

        Stack<MazeCell> stack = new Stack<MazeCell>();
        do
        {
            List<MazeCell> unvisitedNeighbors = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbors.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbors.Add(maze[x, y - 1]);
            if (x < Width - 1 && !maze[x + 1, y].Visited) unvisitedNeighbors.Add(maze[x + 1, y]);
            if (y < Height - 1 && !maze[x, y + 1].Visited) unvisitedNeighbors.Add(maze[x, y + 1]);

            if (unvisitedNeighbors.Count > 0)
            {
                MazeCell chosen = unvisitedNeighbors[UnityEngine.Random.Range(0, unvisitedNeighbors.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);

                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
            {
                a.Bottom = false;
                b.Up = false;
            }
            else
            {
                a.Up = false;
                b.Bottom = false;
            }
        }
        else if (a.Y == b.Y)
        {
            if (a.X > b.X)
            {
                a.Left = false;
                b.Right = false;
            }
            else
            {
                a.Right = false;
                b.Left = false;
            }
        }
    }
}


