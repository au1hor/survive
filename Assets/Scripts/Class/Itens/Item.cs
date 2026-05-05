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
public static class chanceTypeItem
{
    public static Dictionary<TypeItem,float> chanceItens;
    public static void init(chanceTypesSo typesChance)
    {
        chanceItens = new Dictionary<TypeItem, float>();
        for (int i = 0; i < typesChance.typesItem.Count; i++)
        {
            chanceItens[typesChance.typesItem[i]] = typesChance.Chance[i];
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
    public Item(string itemName, TypeItem typeItem)
    {
        this.itemName = itemName;
        this.typeItem = typeItem;
        this.rarity = sortRarity();
       
    }
}
public class weapon:Item
{
    public TypeWeapons typeWeapon;
    public float damage;
    public float range;

    public weapon(string itemName,Vector2 rangeDamage, Vector2 rangeRange)
    :base(itemName,TypeItem.weapon)
    {
        this.damage = Random.Range(rangeDamage.x,rangeDamage.y) ;
        this.range = Random.Range(rangeRange.x,rangeRange.y);   
    }
}
public class Food : Item
{
    public float satiety;
    public int amount;
    public Food(string intemName,float satiety,int amount)
    :base(intemName, TypeItem.consumable)
    {
        this.satiety = satiety;
        this.amount = amount;
    }
}
