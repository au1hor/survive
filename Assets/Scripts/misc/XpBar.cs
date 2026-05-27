using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text textBar;
    void OnEnable()
    {
        playerEvents.OnAfterGetXp += updateBar;
    }
    void OnDisable()
    {
        playerEvents.OnAfterGetXp -= updateBar;
    }
    public void updateBar(PlayerStats player)
    {
        slider.maxValue = player.maxXp;
        slider.value = player.xp;
        textBar.text = $"{textFormater.FormaterNumber(player.xp)}/{textFormater.FormaterNumber(player.maxXp)}";
    }
}
