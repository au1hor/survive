using System;
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
public class Item
{
    public string itemName;
    public TypeItem typeItem;
    public float cost;
    public Item(string itemName, TypeItem typeItem, float cost)
    {
        this.itemName = itemName;
        this.typeItem = typeItem;
        this.cost = cost;
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
