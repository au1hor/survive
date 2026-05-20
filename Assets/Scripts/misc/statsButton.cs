using UnityEngine;

public class statsButton : MonoBehaviour
{
    public void UpStat()
    {
        statsTab statsTab = GetComponentInParent<statsTab>();
        PlayerStats.instance.UpStat(statsTab.statType,1);
    }
}
