using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public GameObject player;
    public GameObject fastHands;
    public GameObject prefabSlot;
    public WeaponSo initW;
    public FoodSo initF;
    public Item[] initialItens;
    public List<GameObject> slots = new List<GameObject>();
    void Start()
    {
        setInitialItens();
        addInitItensToIventory();
        createFastHands();
    }
    public void setInitialItens()
    {
        weapon arma = new weapon("DamagedS Wooden Sword");
        arma.setStats(initW.RangeDamage.y,initW.RangeRange.y,initW.RangeBaseWeight.y,0);
        arma.spriteIcon = initW.spriteIcon;
        Food comida = new Food("Bread all fucked");
        comida.setStatus(initF.satiety,initF.amount);
        initialItens = new Item[]{arma,comida};
        
    }
    public void addInitItensToIventory()
    {
        for (int i = 0; i < initialItens.Length; i++)
        {
             PlayerStats.instance.Inventory.Add(i,initialItens[i]);
             Debug.Log(initialItens[i] + "," + i);
        }
       
    }
    private void createFastHands()
    {
        slots.Clear();
        Debug.Log(PlayerStats.instance.Inventory[2]);
        for (int i = 0; i < PlayerStats.instance.playerSlots; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot,fastHands.transform);
            slots.Add(newSlot);
            if ( i < PlayerStats.instance.Inventory.Count)
            {
                    newSlot.name = $"[Slot[{i}]: {PlayerStats.instance.Inventory[i].itemName}]";
                    newSlot.GetComponent<Image>().sprite =PlayerStats.instance.Inventory[i].spriteIcon; 
            }else
            {
                newSlot.name =$"[Slot[{i}]: Empty!!!]";
            }
            newSlot.GetComponentInChildren<TMP_Text>().text = (i +1).ToString();

        }
    }
    public void selectSlot(int indice)
    {
        Debug.Log(indice);
        for (int i = 0; i < slots.Count; i++)
        {
            if (i +1!= indice)
            {
             
                slots[i].GetComponentInChildren<Image>().color = Color.white;
            }else
            {
                slots[i].GetComponentInChildren<Image>().color = Color.yellow;
            }
            
        }
       
        PlayerStats.instance.actualSlot = indice;
        
    }
}
