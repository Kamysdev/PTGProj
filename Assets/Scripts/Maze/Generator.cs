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
        AddCycles(cells, (Width * Height) / 10);

        Maze maze = new Maze();
        maze.cells = cells;

        return maze;
    }

    public Maze GenerateMazeAldousBroder(int width, int height)
    {
        this.Width = width;
        this.Height = height;

        MazeCell[,] cells = new MazeCell[Width, Height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                cells[x, y] = new MazeCell { X = x, Y = y };

        int total = Width * Height;
        int visited = 1;

        int startX = Random.Range(0, Width);
        int startY = Random.Range(0, Height);

        MazeCell current = cells[startX, startY];
        current.Visited = true;

        while (visited < total)
        {
            List<MazeCell> neighbors = GetNeighbors(cells, current.X, current.Y);
            MazeCell next = neighbors[Random.Range(0, neighbors.Count)];

            if (!next.Visited)
            {
                RemoveWall(current, next);
                next.Visited = true;
                visited++;
            }

            current = next;
        }

        //foreach (var c in cells) c.Visited = false;

        AddCycles(cells, (Width * Height) / 10);

        return new Maze { cells = cells };
    }

    private List<MazeCell> GetNeighbors(MazeCell[,] maze, int x, int y)
    {
        List<MazeCell> list = new List<MazeCell>();

        if (x > 0) list.Add(maze[x - 1, y]);
        if (x < Width - 1) list.Add(maze[x + 1, y]);
        if (y > 0) list.Add(maze[x, y - 1]);
        if (y < Height - 1) list.Add(maze[x, y + 1]);

        return list;
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

    private void AddCycles(MazeCell[,] maze, int cycles)
    {
        int width = maze.GetLength(0);
        int height = maze.GetLength(1);

        for (int i = 0; i < cycles; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);

            MazeCell a = maze[x, y];

            List<MazeCell> neighbors = new List<MazeCell>();

            if (x > 0) neighbors.Add(maze[x - 1, y]);
            if (y > 0) neighbors.Add(maze[x, y - 1]);
            if (x < width - 1) neighbors.Add(maze[x + 1, y]);
            if (y < height - 1) neighbors.Add(maze[x, y + 1]);

            MazeCell b = neighbors[Random.Range(0, neighbors.Count)];

            if (!IsConnected(a, b)) RemoveWall(a, b);
        }
    }

    private bool IsConnected(MazeCell a, MazeCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) return !a.Bottom;
            if (a.Y < b.Y) return !a.Up;
        }
        if (a.Y == b.Y)
        {
            if (a.X > b.X) return !a.Left;
            if (a.X < b.X) return !a.Right;
        }
        return false;
    }

    public int[,] CalculateDistances(MazeCell[,] maze, int startX, int startY)
    {
        int w = maze.GetLength(0);
        int h = maze.GetLength(1);
        int[,] dist = new int[w, h];

        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                dist[x, y] = -1;

        Queue<MazeCell> q = new Queue<MazeCell>();
        MazeCell start = maze[startX, startY];
        dist[startX, startY] = 0;
        q.Enqueue(start);

        while (q.Count > 0)
        {
            MazeCell c = q.Dequeue();
            int d = dist[c.X, c.Y];

            // left
            if (!c.Left)
            {
                if (dist[c.X - 1, c.Y] == -1)
                {
                    dist[c.X - 1, c.Y] = d + 1;
                    q.Enqueue(maze[c.X - 1, c.Y]);
                }
            }

            // right
            if (!c.Right)
            {
                if (dist[c.X + 1, c.Y] == -1)
                {
                    dist[c.X + 1, c.Y] = d + 1;
                    q.Enqueue(maze[c.X + 1, c.Y]);
                }
            }

            // up
            if (!c.Up)
            {
                if (dist[c.X, c.Y + 1] == -1)
                {
                    dist[c.X, c.Y + 1] = d + 1;
                    q.Enqueue(maze[c.X, c.Y + 1]);
                }
            }

            // down
            if (!c.Bottom)
            {
                if (dist[c.X, c.Y - 1] == -1)
                {
                    dist[c.X, c.Y - 1] = d + 1;
                    q.Enqueue(maze[c.X, c.Y - 1]);
                }
            }
        }

        return dist;
    }

    public (int exitX, int exitY) FindExitOnBorder(int[,] dist)
    {
        int w = dist.GetLength(0);
        int h = dist.GetLength(1);

        int bestX = 0;
        int bestY = 0;
        int bestD = -1;

        for (int x = 0; x < w; x++)
        {
            if (dist[x, 0] > bestD)
            {
                bestD = dist[x, 0];
                bestX = x;
                bestY = 0;
            }

            if (dist[x, h - 1] > bestD)
            {
                bestD = dist[x, h - 1];
                bestX = x;
                bestY = h - 1;
            }
        }

        for (int y = 0; y < h; y++)
        {
            if (dist[0, y] > bestD)
            {
                bestD = dist[0, y];
                bestX = 0;
                bestY = y;
            }

            if (dist[w - 1, y] > bestD)
            {
                bestD = dist[w - 1, y];
                bestX = w - 1;
                bestY = y;
            }
        }

        return (bestX, bestY);
    }

    public List<MazeCell> FindPath(MazeCell[,] maze, int[,] dist, int startX, int startY, int endX, int endY)
    {
        List<MazeCell> path = new List<MazeCell>();
        MazeCell current = maze[endX, endY];

        path.Add(current);
        int d = dist[endX, endY];

        while (d > 0)
        {
            int x = current.X;
            int y = current.Y;

            if (x > 0 && !current.Left && dist[x - 1, y] == d - 1)
            {
                current = maze[x - 1, y];
            }
            else if (x < maze.GetLength(0) - 1 && !current.Right && dist[x + 1, y] == d - 1)
            {
                current = maze[x + 1, y];
            }
            else if (y > 0 && !current.Bottom && dist[x, y - 1] == d - 1)
            {
                current = maze[x, y - 1];
            }
            else if (y < maze.GetLength(1) - 1 && !current.Up && dist[x, y + 1] == d - 1)
            {
                current = maze[x, y + 1];
            }
            else
            {
                break;
            }

            Debug.Log("step to (" + current.X + ", " + current.Y + ") with distance " + (d - 1));

            path.Add(current);
            d--;
        }

        path.Reverse();
        return path;
    }

}


