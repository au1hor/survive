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
    string Name => name;
    public float Health => health;
    public float Damage =>damage;
    public float Speed => speed;
    public float AttackSpeed => attackSpeed;
    public Char(string name, float health, float damage, float speed, float attackSpeed)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.attackSpeed = attackSpeed;
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
        if (s == 2)
        {
            log = $@"A {strColor(name,"yellow")} is currently created. they stats are:
            {oColor(nameof(health),health)} | {oColor(nameof(damage),damage)}
            {oColor(nameof(speed),speed)} | {oColor(nameof(attackSpeed),attackSpeed)}
            word wrap is good???";
        }else
        {
            log = $"{misc.SetColor("red")}Go fuck Yourselv{misc.CloseColor()}";
        }
         
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
}

