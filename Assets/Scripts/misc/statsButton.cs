using UnityEngine;

public class statsButton : MonoBehaviour
{
    public void UpStat()
    {
        statsTab statsTab = GetComponentInParent<statsTab>();
        if (Input.GetKey(KeyCode.LeftControl))
        {
            PlayerStats.instance.UpStat(statsTab.statType,1,10);
        }else
        {
            PlayerStats.instance.UpStat(statsTab.statType,1);
        }
       
    }
}
