using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mazeHandler;

    public Cell CellPrefab;
    public Vector2 CellSize = new Vector2(1, 1);

    public int Width = 10;
    public int Height = 10;

    public void GenerateMaze()
    {
        foreach (Transform child in mazeHandler.transform)
        {
            Destroy(child.gameObject);
        }

        Generator generator = new Generator();
        Maze maze = generator.GenerateMaze(Width, Height);

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
