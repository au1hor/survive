using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScreenManager : MonoBehaviour
{
    public Button ExploreButton;
    public GameObject guildHubScreen;
    public GameObject exploreHubScreen;
    public GameObject shopHubScreen;



    public void ExploreClick()
    {
        guildHubScreen.gameObject.SetActive(false);
        exploreHubScreen.gameObject.SetActive(true);
    }
    public void ShopClick()
    {
        guildHubScreen.gameObject.SetActive(false);
        shopHubScreen.gameObject.SetActive(true);
    }
    public void goToBattleScene()
    {
        SceneManager.LoadScene("battleScene");
    }
}
