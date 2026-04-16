using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour
{
    public static Misc Instance{get; private set;}
    public Dictionary<string,string> colors = new Dictionary<string, string>()
    {
        {"red","#FF0000"},
        {"green","#00FF00"},
        {"blue","#0000FF"},
        {"yellow","#FFFF00"},
        {"orange","#FFA500"},
        {"darkPurple","#2e0e2e"}

    };
    
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }else
        {
            Instance = this;
        }
    }
    public string SetColor(string color)
    {
        string colorSet = $"<color={colors[color]}>";
        return colorSet;
    }
    public string CloseColor()
    {
        return $"</color>";
    }
    public string ColorStr(string str, string color)
    {
        return $"{SetColor(color) + str + CloseColor()}";
    }
    public string ColorStats(string name, float value = 0)
    {
        string color ="";
        switch (name)
        {
            default:
            color = "darkPurple";
            break;
            case "health":
            color = "green";
            break;
             case "damage":
            color = "red";
            break;
             case "speed":
            color = "blue";
            break;
             case "attackSpeed":
            color = "orange";
            break;
            
        }
        string open = SetColor(color);
        string mid = $"{name}[{value:f1}]";
        string close = CloseColor();
        string colorStats = open + mid + close;
        return colorStats;
    }
}
