using UnityEngine;

public class VampireHit:MonoBehaviour
{
    PlayerStats player;
    PlayerUi playerUi;
    public float percentLifeSteal = 0.2f;
    void Awake()
    {
        player = GetComponent<PlayerStats>();
        playerUi = GetComponent<PlayerUi>();
    }
    void OnEnable()
    {
        CombatEvents.onBeforeEnemyDamaged += Absorb;
    }
    void OnDisable()
    {
         CombatEvents.onBeforeEnemyDamaged -= Absorb;
    }
    void Absorb(enemieStats enemieStats, DamageInfo damageInfo)
    {
        float absorb = damageInfo.damage * 0.2f;
        player.Heal(absorb);
        Debug.Log("sugou");
    }
}