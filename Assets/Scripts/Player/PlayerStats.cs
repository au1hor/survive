using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerNick = "Adatadataata";
    public InventoryUi inventoryUi;
    public static PlayerStats instance{get;private set;}
    public enum StatType
    {
        HP,
        MP,
        STR,
        INT,
        VIT,
        AGI,
        DEX,
        LUK,
        ATK,
        MATK,
        DEF,
        MDEF,
        CRIT,
        SPD,
        //plus statsu
        MPREGEN,
        CRITCHANCE,
        REGEN,
        CDR,
    }
    public class statValues
    {
        public float value;
        public float multi = 0.66f;
        public float bonus;
        public float finalValue{get{return value += bonus;}}
    }
    public Dictionary<StatType,statValues> stats = new Dictionary<StatType, statValues>();
    public Dictionary<StatType,StatType> proportionality = new Dictionary<StatType, StatType>()
    {
        {StatType.STR,StatType.ATK},
        {StatType.INT,StatType.MP},
        {StatType.VIT,StatType.HP},
        {StatType.AGI,StatType.SPD},
        {StatType.DEX,StatType.DEF},
        {StatType.LUK,StatType.CRITCHANCE},
    };
     public Dictionary<StatType,StatType> subProportionality = new Dictionary<StatType, StatType>()
    {
        {StatType.STR,StatType.MATK},
        {StatType.INT,StatType.MATK},
        //{StatType.INT,StatType.STR},
        {StatType.VIT,StatType.ATK},
        {StatType.AGI,StatType.CDR},
        {StatType.DEX,StatType.SPD},
        {StatType.LUK,StatType.CRIT},
    };
    public int levelPoints;    
    //moneys and xp
    public float gold;
    public int level;
    public float currentHp;
    public float xp;
    public float maxXp;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
        foreach (StatType stat  in System.Enum.GetValues(typeof(StatType)))
        {
            stats.Add(stat,new statValues());
        }
        stats[StatType.HP].value = 10;
        stats[StatType.SPD].value =20;
        stats[StatType.ATK].value =1;

    }
    public void Start()
    {
        currentHp = stats[StatType.HP].finalValue;
    }
    public void TakeDamage(DamageInfo info)
    {
        playerEvents.OnbeforeGetDamage?.Invoke(this,info);
        currentHp +=info.damage;
        playerEvents.OnafterGetDamage?.Invoke(this,info);
        inventoryUi.updateUi();
        if (currentHp <= 0)
        {
            death();
        }
    }
    public void Heal(float value)
    {
        playerEvents.OnBeforeGetHeal?.Invoke(this,value);
        currentHp += value;
        PlayerUi.Instance.VampireAbsorb(transform.position,value);
        inventoryUi.updateUi();
        if (currentHp < stats[StatType.HP].finalValue && value + currentHp < stats[StatType.HP].finalValue)
        {
           
        }
        playerEvents.OnAfterGetHeal?.Invoke(this,value);
        
    }
    public void gainXp(float value)
    {
        xp += value;
        if (xp >= maxXp)
        {
            int levels = 0;
            while(xp >= maxXp)
            {
                xp -= maxXp;
                maxXp += maxXp * 0.25f;
                levels ++;
                levelPoints ++;
            }
            levelUp(levels);
        }
        Debug.Log(value);
        
    }
    public void UpStat(StatType type, float value,int quant =1)
    {
        for (int i = 0; i < quant; i++)
        {
            stats[type].value += value;
            levelPoints --;
            stats[proportionality[type]].value += (stats[type].finalValue > 0?stats[type].finalValue:1)/5.5f;
            if (proportionality[type] == StatType.HP)
            {
                if (currentHp == stats[StatType.HP].finalValue)
                {
                    currentHp = stats[StatType.HP].finalValue;
                }
                else if (currentHp < stats[StatType.HP].finalValue)
                {
                    float heal = currentHp *0.1f;
                    if (heal + currentHp < stats[StatType.HP].finalValue)
                    {
                          Debug.Log(stats[StatType.HP].finalValue + "sa dasdbsadby uasduavu sadbu");
                          currentHp += heal;
                    }
                  
                }
            }
            stats[subProportionality[type]].value +=(stats[type].finalValue > 0?stats[type].finalValue:1)/51.5f;
        }
        inventoryUi.updateUi();
    }
    public void levelUp(int value)
    {
        PlayerUi.Instance.LvUpPopUp();
        inventoryUi.ShowPlusStats();
        level += value;
    }
      public void gainGold(float value)
    {
         gold += value;
    }
    public void death()
    {
        Destroy(this.gameObject);
    }

}
