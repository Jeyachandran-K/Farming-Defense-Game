using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GridManager
{
    private int width;
    private int height;
    private int cellSize;
    private readonly float cellOffset = 0.5f;
    
    private int[,]  grid;

    public GridManager(int width, int height,int cellSize)
    {
        grid = new int[width,height];
    }

    public Vector3 GridToWorldPosition(Vector2 gridPosition)
    {
        return new Vector3(gridPosition.x+cellOffset,0,gridPosition.y+cellOffset);
    }

    public Vector2 WorldToGridPosition(Vector3 worldPosition)
    {
        return new Vector2(worldPosition.x+width/2,worldPosition.z+height/2);
    }
    public int[,] GetGrid()
    {
        return grid;
    }
}
