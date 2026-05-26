using UnityEngine;

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