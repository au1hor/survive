using UnityEngine;
using UnityEngine.UI;

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
