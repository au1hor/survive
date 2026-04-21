using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class CharCard : MonoBehaviour
{
    public GameObject boxNameLv;
    public GameObject boxPfp;
    public GameObject boxClass;
    public GameObject boxHealth;
    public GameObject boxDamage;
    public GameObject boxSpeed;
    public GameObject boxAttackspeed; 
    public List<Char.info> infos;

    void Start()
    {
        UpdateUi();
    }
    public void SetChildText(GameObject boxStats,Char.info info)
    { 
        if (info.infoName == "Name" || info.infoName == "Level")
        {
            if (info.infoName == "Name")
            {
                  boxStats.GetComponentInChildren<TMP_Text>().text =info.valueString;
                  return;
            }
            boxStats.GetComponentInChildren<TMP_Text>().text += $" LV: {info.valueInt:F0}";
        }else
        {
           boxStats.GetComponentInChildren<TMP_Text>().text = $"{info.infoName}: {info.valueFloat:F1}";
        }
    }
    public void UpdateUi()
    {
       foreach (var info in infos)
       {
        switch (info.infoName)
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

