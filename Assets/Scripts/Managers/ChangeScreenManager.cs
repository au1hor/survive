using UnityEngine;
using UnityEngine.UI;

public class ChangeScreenManager : MonoBehaviour
{
    public Button ExploreButton;
    public GameObject guildHubScreen;
    public GameObject exploreHubScreen;



    public void ExploreClick()
    {
        guildHubScreen.gameObject.SetActive(false);
        exploreHubScreen.gameObject.SetActive(true);
    }
}
