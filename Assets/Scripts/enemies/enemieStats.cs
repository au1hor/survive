using UnityEngine;

public class enemieStats : MonoBehaviour
{
    public enemieBehaviour enemieBehaviour;
    public PlayerStats PlayerStats;
    public float life = 100;
    public float speed = 15;
    public float reach;
    public float xpCarry;
    public float goldCarry;
    public float vision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        enemieBehaviour = this.GetComponent<enemieBehaviour>();
    }
    public void changeLife(float value)
    {
        if (value <= 0)
        {
            life +=value;
            enemieBehaviour.changingState(enemieBehaviour.states.hitted);
            if (life <= 0)
            {
                Death();
            }

        }
        else
        {
            Debug.Log("Curado ou buff");
        }
    }
    public void Death()
    {
        PlayerStats.xp += xpCarry;
        PlayerStats.gold += goldCarry;
        Destroy(this.gameObject,0.1f);
    }
}
