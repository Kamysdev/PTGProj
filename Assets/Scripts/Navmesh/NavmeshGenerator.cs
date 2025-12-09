using Unity.AI.Navigation;
using UnityEngine;

public class NavmeshGenerator : MonoBehaviour
{
    public NavMeshSurface surface;

    public void BuildNavMesh()
    {
        if (surface != null)
        {
            surface.BuildNavMesh();
        }
        else
        {
            Debug.LogError("NavMeshSurface is not assigned.");
        }
    }
}
