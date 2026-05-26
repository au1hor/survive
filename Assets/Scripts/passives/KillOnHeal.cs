using UnityEngine;

public class HealOnKill : MonoBehaviour
{
    public int healValue = 1;
    PlayerStats player;
    void Awake()
    {
        player = GetComponent<PlayerStats>();
    }
    void OnEnable()
    {
        CombatEvents.onEnemyKilled += Heal;
    }
    void OnDisable()
    {
         CombatEvents.onEnemyKilled -= Heal;
    }
    void Heal(enemieStats enemy,DamageInfo damage)
    {
        player.Heal(healValue);
        Debug.Log("curado ");
    }
}
