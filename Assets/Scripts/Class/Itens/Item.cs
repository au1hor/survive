using System.Collections.Generic;
using UnityEngine;
public enum TypeItem
{
    weapon, 
    consumable,
    tools,
    acessories,
    armor,



}
public enum TypeWeapons
{
    dagger,
    doubleDagger,
    sword,
    longSword,
    doubleSword,
    tripleSword,
    massiveSword,
    katanna,
    doubleKatanna,
    tripleKatanma,
    odachi,

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
    public static Dictionary<Rarity, float> rarityItens;
    public static Dictionary<Rarity, float> rarityMulti;
    public static void init(RaritysSo raritysSo)
    {
        rarityItens = new Dictionary<Rarity, float>();
        rarityMulti = new Dictionary<Rarity, float>();
        for (int i = 0; i < raritysSo.rarities.Count; i++)
        {
            rarityItens[raritysSo.rarities[i]] = raritysSo.Chances[i];
            rarityMulti[raritysSo.rarities[i]] = raritysSo.Multi[i];
        }
    }
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
        foreach (var item in RarityTable.rarityItens)
        {
            total += item.Value;
        }
        float rng = Random.Range(0,total);
        float ac = 0;
        foreach (var item in RarityTable.rarityItens)
        {
            ac+=item.Value;
            if (ac >= rng)
            {
                return item.Key;
            }
        }
        return Rarity.common;
    }
    public void raritySetCost()
    {
        this.cost *= RarityTable.rarityMulti[this.rarity];
    }
    public Item(string itemName, TypeItem typeItem, Vector2 cost)
    {
        this.itemName = itemName;
        this.typeItem = typeItem;
        this.rarity = sortRarity();
        this.cost = Random.Range(cost.x,cost.y);
       
    }
}
public class weapon:Item
{
    public TypeWeapons typeWeapon;
    public float damage;
    public float range;
    public float attackSpeed;
    public weapon(string itemName,Vector2 rangeDamage, Vector2 rangeRange, Vector2 rangeAttackSpeed,Vector2 cost)
    :base(itemName,TypeItem.weapon,cost)
    {
        this.damage = Random.Range(rangeDamage.x,rangeDamage.y) ;
        this.range = Random.Range(rangeRange.x,rangeRange.y);
        this.attackSpeed = Random.Range(rangeAttackSpeed.x,rangeAttackSpeed.y);
        
    }


}
public class Food : Item
{
    public float satiety;
    public int amount;
    public Food(string intemName,float satiety,int amount,Vector2 cost) : base(intemName, TypeItem.consumable, cost)
    {
        this.satiety = satiety;
        this.amount = amount;
    }
}
