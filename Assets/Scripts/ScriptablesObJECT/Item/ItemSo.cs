using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Objects/ItemSo")]
public class ItemSo : ScriptableObject
{
    public string itemName;
    public Vector2 cost;
    
}
[CreateAssetMenu(fileName = "FoodSo", menuName = "Scriptable Objects/FoodSo")]
public class Food : ItemSo
{
    public TypeItem typeItem = TypeItem.consumable;
    public float satiety;
    //pro futuro estado ce ta podre ou etc
}
[CreateAssetMenu(fileName ="SwordSo", menuName ="Scriptable Objects/SwordSo")]
public class SwordSo : ItemSo
{
    public TypeItem typeItem = TypeItem.weapon;
    public TypeWeapons typeWeapon= TypeWeapons.sword;
    public string creatorName;
    public Vector2 RangeDamage;
    public Vector2 RangeRange;
    public Vector2 RangeAttackspeed;
    
}
