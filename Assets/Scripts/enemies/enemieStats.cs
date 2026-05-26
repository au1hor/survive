using UnityEngine;

public class enemieStats : MonoBehaviour
{
   
    public enemieBehaviour enemieBehaviour;
    public PlayerStats PlayerStats;
    public enemieUi enemieUi;
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
        enemieUi = GetComponent<enemieUi>();
    }
    public void TakeDamage(DamageInfo damageInfo)
    {
        CombatEvents.onBeforeEnemyDamaged?.Invoke(this,damageInfo);
        life -=damageInfo.damage;
        enemieUi.damagePopUp(transform.position,damageInfo.damage);
        enemieBehaviour.changingState(enemieBehaviour.states.hitted);
         CombatEvents.onAfterEnemyDamaged?.Invoke(this,damageInfo);
        if (life <= 0)
        {
            Death();
            CombatEvents.onEnemyKilled?.Invoke(this,damageInfo);
        }
    }
    public void Death()
    {
        PlayerStats.gainXp(xpCarry);
        PlayerStats.gainGold(goldCarry);
        Destroy(this.gameObject,0.1f);
    }
}
