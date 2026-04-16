using System.Collections.Generic;
using UnityEngine;

public class FactoryChar{
    ClasseSo classeSo;
    
    public FactoryChar(ClasseSo classeSo)
    {
        this.classeSo = classeSo;
    }
    public float SortRangeF(FloatRange range)
    {
       float result = Random.Range(range.min,range.max);
       return result;
    }
    public int SortRangeI(IntRange range)
    {
       int result = Random.Range(range.min,range.max);
       return result;
    }
    public Char Create(string name)
    {
        float health = SortRangeF(classeSo.health);
        float damage = SortRangeF(classeSo.damage);
        float speed = SortRangeF(classeSo.speed);
        float attackSpeed = SortRangeF(classeSo.attackSpeed);
          Debug.Log(health);
        return new Char(name,health,damage,speed,attackSpeed);
      
    }
}

public class Char
{
    string name;
    float health;
    float damage;
    float speed;
    float attackSpeed;
    int level;
    string Name => name;
    public float Health => health;
    public float Damage =>damage;
    public float Speed => speed;
    public float AttackSpeed => attackSpeed;
    public int Level => level;
     List<info> infos= new List<info>();
    public Dictionary<string,object> objs;
    public enum valueType
    {
        Int,
        Float,
        String
    }
    public enum ClassType
    {
        Assasin,
        Spada,
        Warrior
    }
    [System.Serializable]
    public struct info
    {
       public string infoName;
       public valueType valueType;
       public int valueInt;
       public float valueFloat;
       public string valueString;
    }
    public Char(string name, float health, float damage, float speed, float attackSpeed)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
        level = Random.Range(0,1000);
        objs = new Dictionary<string, object>()
        {
            {"Name",Name},
            {"Health",Health},
            {"Damage",Damage},
            {"Class",ClassType.Assasin.ToString()},
            {"Speed",speed},
            {"AttackSpeed",AttackSpeed},
            {"Level",Level}
        };
    }
    public void Death()
    {
        Debug.Log("Death caught me!!");
    }
    public string TextLog()
    {
        Misc misc = Misc.Instance;
        string oColor(string x,float y) => misc.ColorStats(x,y);
        string strColor(string x,string y) => misc.ColorStr(x,y);
        string log;
        var s = Random.Range(1,3);
        log = $@"A {strColor(name,"yellow")} is currently created. they stats are:
            {oColor(nameof(health),health)} | {oColor(nameof(damage),damage)}
            {oColor(nameof(speed),speed)} | {oColor(nameof(attackSpeed),attackSpeed)}
            word wrap is good???";
        return log;
    }
    public void SetHealth(float value)
    {
        health += value;
        if (health <= 0)
        {
            Death();
        }
    }
    public Dictionary<string,object> getAllStats()
    {
        foreach (var entry in objs)
        {
            string n = entry.Key;
            valueType vType = valueType.Float;
            info newInfo = new info(){infoName = entry.Key};
            switch (entry.Value)
            {
                case int i:
                vType = valueType.Int;
                newInfo.valueInt = i;
                break;
                case float f:
                vType = valueType.Float;
                newInfo.valueFloat = f;
                break;
                case string s:
                vType = valueType.String;
                newInfo.valueString = s;
                break;
            }
            newInfo.valueType = vType;
            infos.Add(newInfo);
        }
        return objs;
    }
}

