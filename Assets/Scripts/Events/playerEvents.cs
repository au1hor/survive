using System;
using UnityEngine;

public static class playerEvents{
    public static Action<PlayerStats,DamageInfo>OnbeforeGetDamage;
    public static Action<PlayerStats,DamageInfo>OnafterGetDamage;
    public static Action<PlayerStats>OnBeforeGetXp;
    public static Action<PlayerStats>OnAfterGetXp;
    public static Action<PlayerStats,DamageInfo>OnPlayerKilled;
    public static Action<PlayerStats,float>OnBeforeGetHeal;
    public static Action<PlayerStats,float>OnAfterGetHeal;
    public static Action<SpriteRenderer>OnTurnToTop;
    public static Action<SpriteRenderer>OnTurnToDown;
    public static Action<SpriteRenderer>OnTurnToleft;
    public static Action<SpriteRenderer>OnTurnToRight;


}