using UnityEngine;

[CreateAssetMenu(fileName = "ItemSo", menuName = "Scriptable Objects/ItemSo")]
public class ItemSo : ScriptableObject
{
    public string itemName;
    public Sprite spriteIcon;
    public Vector2 cost;
    
}
[CreateAssetMenu(fileName = "FoodSo", menuName = "Scriptable Objects/FoodSo")]
public class FoodSo : ItemSo
{
    public TypeItem typeItem = TypeItem.consumable;
    public Rarity rarity;
    public int amount;
    public float satiety;
    //pro futuro estado c
    // e ta podre ou etc
}
[CreateAssetMenu(fileName ="WeaponSo", menuName ="Scriptable Objects/WeaponSo")]
public class WeaponSo : ItemSo
{
    public TypeItem typeItem = TypeItem.weapon;
    public TypeWeapons typeWeapon= TypeWeapons.sword;
    public string creatorName;
    public Vector2 RangeDamage;
    public Vector2 RangeRange;
    public Vector2 RangeBaseWeight;
    
}
