using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager : MonoBehaviour
{
    public int height;
    public int width;
    public float cellSize;
    public SpriteRenderer testSpr;
    public Vector3 offSet;
    public GameObject testObj;
    Grid.GridCell[,] grid;

    void Start()
    {
        creteGrid();
        Sprite sprite = testSpr.sprite;
        GetBuildingSize(sprite);

    }
    void Update()
    {
        checkMousePos(testObj);
    }
    public void creteGrid()
    {
      
        grid = new Grid.GridCell[width,height];
        offSet = new Vector3((width * cellSize) / 2f, (height * cellSize) / 2f, 0);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x,y] = new Grid.GridCell(x,y);
            }
        }
    }
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        worldPos += offSet;
        int x = Mathf.FloorToInt(worldPos.x / cellSize);
        int y = Mathf.FloorToInt(worldPos.y/cellSize);
        return new Vector2Int(x,y);
    } 
    public Vector3 GridToWorld(Vector2Int gridPos)
    {
        return new Vector3(gridPos.x * cellSize,gridPos.y *  cellSize) - offSet;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * cellSize,y * cellSize,0) - offSet;
                Gizmos.DrawWireCube(pos,Vector3.one * cellSize);
            }
        }
    }
    public Vector2Int GetBuildingSize(Sprite sprite)
    {
        float pixerPerSize = 32f;
        int width = Mathf.RoundToInt(sprite.rect.width / pixerPerSize);
        int height = Mathf.RoundToInt(sprite.rect.height / pixerPerSize);
        Debug.Log(new Vector2Int(width,height));
        return new Vector2Int(width,height);
        
    }
    public void checkMousePos(GameObject build)
    {
        SpriteRenderer sprRender = build.GetComponent<SpriteRenderer>();
        Sprite spr = sprRender.sprite;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2Int pos =  WorldToGrid(mousePos);
         build.transform.position = mousePos;
        Vector2Int size = GetBuildingSize(spr);
        if (canPlace(pos,size))
        {
        sprRender.color = Color.green;
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBuilding(pos,size,build);
        }
        }else
            {
                sprRender.color = Color.red;
            }
        

    }
    public bool canPlace(Vector2Int pos, Vector2Int size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                int checkX = pos.x + x;
                int checkY = pos.y + y;
                if (checkX < 0 || checkY < 0 || checkX > width || checkY > height)
                {
                    return false;
                }
                if (grid[checkX,checkY].type != Grid.Gridtype.Empty)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void PlaceBuilding(Vector2Int pos, Vector2Int size,GameObject build)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
             grid[pos.x + x , pos.y +y].type = Grid.Gridtype.Building;   
            }
        }
        Instantiate(build,GridToWorld(pos),quaternion.identity);
    }

}
