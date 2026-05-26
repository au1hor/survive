using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Objects/ItemSo")]
public class ItemSo : ScriptableObject
{
    public string itemName;
    public Sprite spriteIcon;
    public Sprite[]Animation;
    public Vector2 cost;
    
}

