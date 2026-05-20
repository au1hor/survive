using System.Collections.Generic;
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
    }
    public class statValues
    {
        public float value;
        public float bonus;
        public float finalValue{get{return value += bonus;}}
    }
    public Dictionary<StatType,statValues> stats = new Dictionary<StatType, statValues>();
    public int levelPoints;    
    //moneys and xp
    public float gold;
    public int level;
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
        stats[StatType.HP].value = 100;
        stats[StatType.SPD].value =20;
        stats[StatType.ATK].value =10;

    }
    public void changeLife(float value)
    {
        stats[StatType.HP].value += value;
        if (stats[StatType.HP].value <= 0)
        {
            death();
        }
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
    public void UpStat(StatType type, float value)
    {
        stats[type].value += value;
        levelPoints --;
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
