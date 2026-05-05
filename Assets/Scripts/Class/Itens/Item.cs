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
    Rarity sortRarity()
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
    TypeItem sortType()
    {
        float total = 0;
        TypeItem type = TypeItem.consumable;
        foreach (var item in chanceTypeItem.chanceItens)
        {
            total += item.Value;
        }
        float rng = Random.Range(0,total);
        float acc = 0;
        foreach (var item in chanceTypeItem.chanceItens)
        {
            acc += item.Value;
            if (acc >= rng)
            {
                type = item.Key;
                break;
            }
        }
        return type;
    }
     public void setType(bool randomize = false,TypeItem typeItem = TypeItem.weapon)
    {
        if (!randomize)
        {
            this.typeItem = typeItem;
        }else
        {
            this.typeItem = sortType();
        }
    }
    public void setRarity(bool randomize = false,Rarity rarity = Rarity.common)
    {
        if (!randomize)
        {
            this.rarity = rarity;
        }else
        {
            this.rarity = sortRarity();
        }
    }
    public Item(string itemName)
    {
        this.itemName = itemName;
        this.cost = Random.Range(0,9999999);
       
    }
}
public class weapon:Item
{
    public TypeWeapons typeWeapon;
    public float damage;
    public float range;
    public void setByArangeStats()
    {
        WeaponSo wSo = GameLoader.Instance.weaponData;
        this.damage = Random.Range(wSo.RangeDamage.x,wSo.RangeDamage.y);
        this.range = Random.Range(wSo.RangeRange.x,wSo.RangeRange.y);
    }
    public void aplyRarityMulti()
    {
        this.damage *= RarityTable.rarityMulti[this.rarity];
        this.cost *=  RarityTable.rarityMulti[this.rarity];
    }
    public weapon(string itemName)
    :base(itemName)
    {
        
    }
}
public class Food : Item
{
    public float satiety;
    public int amount;
    public Food(string intemName)
    :base(intemName)
    {
        this.typeItem = TypeItem.consumable;
    }
}
