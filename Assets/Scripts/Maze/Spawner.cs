using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    public GameObject mazeHandler;

    public Cell CellPrefab;
    public Vector2 CellSize = new Vector2(1, 1);

    public int Width = 10;
    public int Height = 10;

    //public GameObject minoryObjectPrefab;

    void Start()
    {
    }

    public void GenerateMaze()
    {
        foreach (Transform child in mazeHandler.transform)
        {
            Destroy(child.gameObject);
        }

        Generator generator = new Generator();
        Maze maze = generator.GenerateMaze(Width, Height);

        int startX = 0;
        int startY = Random.Range(0, Height);

        int[,] distances = generator.CalculateDistances(maze.cells, startX, startY);

        //maze.cells[0, startY].Left = false;

        var exit = generator.FindExitOnBorder(distances);
        Debug.Log($"Exit at ({exit.exitX}, {exit.exitY}) with distance {exit}");
        int exitX = exit.exitX;
        int exitY = exit.exitY;

        if (exitX == 0) maze.cells[exitX, exitY].Left = false;
        else if (exitX == Width - 1) maze.cells[exitX, exitY].Right = false;
        else if (exitY == 0) maze.cells[exitX, exitY].Bottom = false;
        else if (exitY == Height - 1) maze.cells[exitX, exitY].Up = false;




        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, 0, z * CellSize.y), Quaternion.identity);

                if (maze.cells[x, z].Left == false) Destroy(c.Left);
                if (maze.cells[x, z].Right == false) Destroy(c.Right);
                if (maze.cells[x, z].Up == false) Destroy(c.Up);
                if (maze.cells[x, z].Bottom == false) Destroy(c.Bottom);

                c.transform.parent = mazeHandler.transform;
            }
        }
    }

    public void GenerateMaze2()
    {
        foreach (Transform child in mazeHandler.transform)
        {
            Destroy(child.gameObject);
        }

        Generator generator = new Generator();
        Maze maze = generator.GenerateMazeAldousBroder(Width, Height);

        int startX = Random.Range(0, Width);
        int startY = Random.Range(0, Height);

        int[,] distances = generator.CalculateDistances(maze.cells, startX, startY);

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int z = 0; z < maze.cells.GetLength(1); z++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, 0, z * CellSize.y), Quaternion.identity);

                if (maze.cells[x, z].Left == false) Destroy(c.Left);
                if (maze.cells[x, z].Right == false) Destroy(c.Right);
                if (maze.cells[x, z].Up == false) Destroy(c.Up);
                if (maze.cells[x, z].Bottom == false) Destroy(c.Bottom);

                c.transform.parent = mazeHandler.transform;
            }
        }
    }
}
