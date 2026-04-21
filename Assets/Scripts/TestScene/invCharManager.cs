using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class invCharManager : MonoBehaviour
{
  
    public Scrollbar VerticalScrollbar;
    public Transform scrollCotent;
    public GameObject cardPrefab;
   
    public void addCardChar(Char @char)
    {
        GameObject card = Instantiate(cardPrefab,scrollCotent);
        card.GetComponent<CharCard>().infos = @char.getAllStats();
        
    }

}
