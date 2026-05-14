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
    public WeaponSo initW1;

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
        arma.Animation = initW.Animation;
        weapon arma2 = new weapon("DamagedS Wooden Sword");
        arma2.setStats(initW1.RangeDamage.y,initW1.RangeRange.y,initW1.RangeBaseWeight.y,0);
        arma2.spriteIcon = initW1.spriteIcon;
        arma2.Animation = initW1.Animation;
        Food comida = new Food("Bread all fucked");
        comida.setStatus(initF.satiety,initF.amount);
        comida.spriteIcon = initF.spriteIcon;
        initialItens = new Item[]{arma,arma2,comida};
        
    }
    public void addInitItensToIventory()
    {
        for (int i = 0; i < initialItens.Length; i++)
        {
            Debug.Log(i);
             PlayerStats.instance.Inventory.Add(i,initialItens[i]);
             Debug.Log(initialItens[i] + "," + i);
        }
       
    }
    private void createFastHands()
    {
        slots.Clear();
        for (int i = 0; i < PlayerStats.instance.playerSlots; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot,fastHands.transform);
            slots.Add(newSlot);
            if ( i < PlayerStats.instance.Inventory.Count)
            {
                    newSlot.name = $"[Slot[{i}]: {PlayerStats.instance.Inventory[i].itemName}]";
                    Item instanc = PlayerStats.instance.Inventory[i];
                    SlotObj slotScript =newSlot.GetComponent<SlotObj>();
                    slotScript.slotNuber.text = (i+1).ToString();
                    slotScript.icon.sprite = instanc.spriteIcon;
                    newSlot.GetComponent<Image>().SetNativeSize();
            }else
            {
                newSlot.name =$"[Slot[{i}]: Empty!!!]";
            }
            newSlot.GetComponentInChildren<TMP_Text>().text = (i +1).ToString();
        }
    }
    public void selectSlot(int indice)
    {
        for (int i = 0; i < slots.Count; i++)
        {
              SlotObj slotScr = slots[i].GetComponent<SlotObj>();
            if (i +1!= indice)
            { 
               slotScr.slotNuber.color  = Color.white;
               slotScr.border.color = Color.white;
            }else
            {
                slotScr.slotNuber.color  = Color.yellow;
                slotScr.border.color = Color.yellow;
            }   
        }
        PlayerStats.instance.actualSlot = indice;
        PlayerStats.instance.actualItem = PlayerStats.instance.Inventory[indice -1];
        if ( PlayerStats.instance.Inventory[indice -1] is weapon wp)
        {

            PlayerStats.instance.gameObject.GetComponent<PlayerAtack>().slashSpr = wp.Animation;
        }
    }
}
