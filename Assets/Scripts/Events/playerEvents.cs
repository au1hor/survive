using System;
using UnityEngine;

public static class playerEvents{
    public static Action<PlayerStats,DamageInfo>OnbeforeGetDamage;
    public static Action<PlayerStats,DamageInfo>OnafterGetDamage;
    public static Action<PlayerStats,DamageInfo>OnPlayerKilled;
    public static Action<PlayerStats,float>OnBeforeGetHeal;
    public static Action<PlayerStats,float>OnAfterGetHeal;


}