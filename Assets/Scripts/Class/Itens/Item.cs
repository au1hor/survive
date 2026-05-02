using System.Collections.Generic;
using UnityEngine;
public enum TypeItem
{
    sword,
    doubleSword,
    longSword,
    spear,
    longSpear,
    dagger,
    doubleDagger,
    consumable,


}
public enum Rarity
{
    common,
    uncommon,
    rare,
    ultraRare,
    Epic,
    legendary,
    unique
}
public static class RarityTable
{
     public static Dictionary<Rarity, float> raridades = new Dictionary<Rarity, float>()
    {
        {Rarity.common,50},
        {Rarity.uncommon,20},
        {Rarity.rare,10},
        {Rarity.ultraRare, 5},
        {Rarity.Epic,8},
        {Rarity.legendary,3.00000009f},
        {Rarity.unique,0.00000001f}
    };
}
public class Item
{
    public string itemName;
    public TypeItem typeItem;
    public Rarity rarity;
    public float cost;
   
    public Rarity sortRarity()
    {
        float total = 0;
        foreach (var item in RarityTable.raridades)
        {
            total += item.Value;
        }
        float rng = Random.Range(0,total);
        float ac = 0;
        foreach (var item in RarityTable.raridades)
        {
            ac+=item.Value;
            if (ac >= rng)
            {
                return item.Key;
            }
        }
        return Rarity.common;
    }
    public Item(string itemName, TypeItem typeItem, float cost)
    {
        this.itemName = itemName;
        this.typeItem = typeItem;
        this.cost = cost;
        this.rarity = sortRarity();

    }

}
public class Sword:Item
{
    public float damage;
    public float range;
    public float attackSpeed;
    public Sword(string itemName,float damage, float range, float attackSpeed,float cost)
    :base(itemName,TypeItem.sword,cost)
    {
        this.damage = damage;
        this.range = range;
        this.attackSpeed = attackSpeed;
        
    }


}
