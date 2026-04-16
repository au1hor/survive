using UnityEngine;

public class invCharManager : MonoBehaviour
{
    public Transform scrollCotent;
    public GameObject cardPrefab;
    public void addCardChar(Char @char)
    {
        GameObject card = Instantiate(cardPrefab,scrollCotent);
        card.GetComponent<CharCard>().infos = @char.getAllStats();
        
    }

}
