using System;
using UnityEngine;

public static class CombatEvents
{
    public static Action<enemieStats,DamageInfo> onBeforeEnemyDamaged;
    public static Action<enemieStats,DamageInfo> onEnemyDamaged;
     public static Action<enemieStats,DamageInfo> onAfterEnemyDamaged;
    public static Action<enemieStats,DamageInfo> onEnemyKilled;
}
