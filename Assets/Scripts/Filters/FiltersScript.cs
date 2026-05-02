using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FiltersScript : MonoBehaviour
{
    public enum Mode
    {
        ascending,
        descending,
        disable,

    }
    public Mode acualMode;
    public int ind = 0;
    ShopManager shopManager;
    public Image iconArrow;
    public ShopManager.Filters filter;
    
}
