using UnityEngine;

public class Grid
{
    public enum Gridtype
    {
        Empty,
        Road,
        Building
    }
    public class GridCell
    {
        public Vector2Int pos;
        public Gridtype type;
        public GridCell(int x, int y)
        {
            pos = new Vector2Int(x,y);
            type = Gridtype.Empty;
        }

    }
}
