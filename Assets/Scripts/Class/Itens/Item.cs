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
public class Item
{
    public string itemName;
    public TypeItem typeItem;
    public Rarity rarity;
    public float cost;
    public Dictionary<Rarity, float> raridades = new Dictionary<Rarity, float>()
    {
        {Rarity.common,30},
        {Rarity.uncommon,20},
        {Rarity.rare,15},
        {Rarity.ultraRare, 15},
        {Rarity.Epic,10},
        {Rarity.legendary,8.00000009f},
        {Rarity.unique,0.00000001f}
    };
    public Rarity sortRarity()
    {
        float total = 0;
        foreach (var item in raridades)
        {
            total += item.Value;
        }
        float rng = Random.Range(0,total);
        float ac = 0;
        foreach (var item in raridades)
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
