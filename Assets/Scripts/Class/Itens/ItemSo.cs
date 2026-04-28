using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Objects/ItemSo")]
public class ItemSo : ScriptableObject
{
    public string itemName;
    
}
[CreateAssetMenu(fileName ="SwordSo", menuName ="Scriptable Objects/EspadaSo")]
public class SwordSo : ItemSo
{
    public TypeItem typeItem = TypeItem.sword;
    public Vector2 RangeDamage;
    public Vector2 RangeRange;
    public Vector2 RangeAttackspeed;
    
}
