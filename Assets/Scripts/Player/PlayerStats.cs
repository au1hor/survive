using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance{get;private set;}
    public float speed;
    public float damage;
    public float life;
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

}
