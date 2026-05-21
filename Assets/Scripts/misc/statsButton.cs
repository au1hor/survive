using UnityEngine;

public class statsButton : MonoBehaviour
{
    public void UpStat()
    {
        statsTab statsTab = GetComponentInParent<statsTab>();
        if (Input.GetKey(KeyCode.LeftControl) && PlayerStats.instance.levelPoints >=10)
        {
            PlayerStats.instance.UpStat(statsTab.statType,1,10);
        }else if (Input.GetKey(KeyCode.LeftControl))
        {
             PlayerStats.instance.UpStat(statsTab.statType,1, PlayerStats.instance.levelPoints);
        }
        else
        {
            PlayerStats.instance.UpStat(statsTab.statType,1);
        }
       
    }
}
