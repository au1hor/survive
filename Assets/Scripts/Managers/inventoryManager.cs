using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject fastHands;
    public GameObject prefabSlot;
    public List<GameObject> slots = new List<GameObject>();
    void Start()
    {
        createFastHands();
    }
    private void createFastHands()
    {
        slots.Clear();
        for (int i = 0; i < PlayerStats.instance.playerSlot; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot,fastHands.transform);
            slots.Add(newSlot);
            newSlot.GetComponentInChildren<TMP_Text>().text = (i +1).ToString();

        }
    }
    public void selectSlot(int indice)
    {
        slots[indice -1].GetComponent<Image>().color = Color.yellow;
        PlayerStats.instance.actualSlot = indice;
        
    }
}
