using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class inventoryManager : MonoBehaviour
{
    public InventoryUi inventoryUi;
    public GameObject player;
    public GameObject inventoryHud;

    public WeaponSo initW;
    public WeaponSo initW1;
    public int playerSlotsBar = 5;
    public Item actualItem;
    public int actualSlot;

    public FoodSo initF;
    public Item[] initialItens;
    public Dictionary<int,Item>Inventory = new Dictionary<int, Item>();
    //INfos
    public TMP_Text title;
    public TMP_Text namePlayer;
    public TMP_Text lv;
    // obj stats

    void Start()
    {
     
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
    public void showInventory()
    {
        if (inventoryHud.gameObject.activeSelf)
        {
            inventoryHud.gameObject.SetActive(false);
        }else
        {
            inventoryHud.gameObject.SetActive(true);
            inventoryUi.updateUi();
        }
    }



}
