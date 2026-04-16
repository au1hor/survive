using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CharCard : MonoBehaviour
{
    public GameObject boxNameLv;
    public GameObject boxPfp;
    public GameObject boxClass;
    public GameObject boxHealth;
    public GameObject boxDamage;
    public GameObject boxSpeed;
    public GameObject boxAttackspeed; 
    public Dictionary<string,object> infos;

    void Start()
    {
        UpdateUi();
    }
    public void SetChildTextSimple(GameObject boxStats, object obj)
    {
        boxStats.GetComponentInChildren<TMP_Text>().text = $"{obj:F1}";
    }
    public void SetChildText(GameObject boxStats,KeyValuePair<string,object> info)
    { 
        
        if (info.Key == "Name" || info.Key == "Level")
        {
            if (info.Key == "Name")
            {
                  boxStats.GetComponentInChildren<TMP_Text>().text =info.Value.ToString();
                  return;
            }
            boxStats.GetComponentInChildren<TMP_Text>().text += $" LV: {info.Value:F0}";
        }else
        {
            SetChildTextSimple(boxStats,info.Value);
        }
        
    }
    public void UpdateUi()
    {
       foreach (var info in infos)
       {
        switch (info.Key)
        {
            case "Name" or "Level":
            SetChildText(boxNameLv,info);
            break;
            case "Class":
            SetChildText(boxClass,info);
            break;
            case "Health":
            SetChildText(boxHealth,info);
            break;
            case "Damage":
            SetChildText(boxDamage,info);
            break;
            case "Speed":
            SetChildText(boxSpeed,info);
            break;
            case "AttackSpeed":
            SetChildText(boxAttackspeed,info);
            break;
        }
       
       }
        
    }
}

