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

    public GameObject inventoryHud;

    public int playerSlotsBar = 5;
    public Item actualItem;
    public int actualSlot;

    public FoodSo initF;
    public Item[] initialItens;
    public List<GameObject> slots = new List<GameObject>();
    public Dictionary<int,Item>Inventory = new Dictionary<int, Item>();
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
        weapon arma2 = new weapon("Steel but not steal");
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
        for (int i = 0; i < playerSlotsBar; i++)
        {
            if (i < initialItens.Length)
            {
                Inventory.Add(i,initialItens[i]);
            }else
            {
                Inventory.Add(i,null);
            }
        }
    }
    private void createFastHands()
    {
        slots.Clear();
        for (int i = 0; i < playerSlotsBar; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot,fastHands.transform);
            slots.Add(newSlot);
            if (Inventory[i] != null)
            {
                    newSlot.name = $"[Slot[{i}]: {Inventory[i].itemName}]";
                    Item instanc = Inventory[i];
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
        actualSlot = indice;
        actualItem = Inventory[indice -1];
    }
    public void showInventory()
    {
        if (inventoryHud.gameObject.activeSelf)
        {
            inventoryHud.gameObject.SetActive(false);
        }else
        {
              inventoryHud.gameObject.SetActive(true);
        }
        
    }

}
