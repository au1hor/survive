using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance{get;private set;}
    public float speed;
    public float damage;
    public float life;
    //moneys and xp
    public float gold;
    public float xp;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }else
        {
            instance = this;
        }
    }
    public void changeLife(float value)
    {
        life += value;
        if (life <= 0)
        {
            death();
        }
    }
    public void death()
    {
        Destroy(this.gameObject);
    }

}
