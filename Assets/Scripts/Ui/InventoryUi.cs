using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUi : MonoBehaviour
{

    public inventoryManager inventoryManager;
    public GameObject prefabSlot;
    public GameObject fastHands;
    public TMP_Text playerName;
    public TMP_Text levelText;
    public TMP_Text lifeMainTxt;

    public List<GameObject> slots = new List<GameObject>();
    [SerializeField] private List<StatUi> statUis = new List<StatUi>();
    [System.Serializable]public class StatUi
    {
        public PlayerStats.StatType statType;
        public statsTab statsTab;
    }
    private Dictionary<PlayerStats.StatType,StatUi> UiDic = new Dictionary<PlayerStats.StatType, StatUi>();
    void Awake()
    {
        foreach (var stat in statUis)
        {
            UiDic.Add(stat.statType,stat);
        }
        inventoryManager.setInitialItens();
        inventoryManager.addInitItensToIventory();
    }
    public void Start()
    {
        createFastHands();
        updateUi();
    }
    public void updateUi()
    {
        playerName.text =  $"Level: {PlayerStats.instance.playerNick}";
        levelText.text = $"Level: {PlayerStats.instance.level}";
        lifeMainTxt.text = $"{PlayerStats.instance.currentHp}/{PlayerStats.instance.stats[PlayerStats.StatType.HP].finalValue}";
        foreach (var item in PlayerStats.instance.stats)
        {
           PlayerStats.StatType type = item.Key;
           if (UiDic.TryGetValue(type, out _))
           {
            UiDic[type].statsTab.value.text = PlayerStats.instance.stats[type].finalValue.ToString("F0");
            UiDic[type].statsTab.statType = type;
           }else
           {
            Debug.Log("Tipo não presente no dicionario");
           }
           
        }
        if (PlayerStats.instance.levelPoints <= 0)
        {
            HiddenPlusStats();
        }
    }
    
    private void createFastHands()
    {
       slots.Clear();
       Debug.Log(inventoryManager.Inventory.Count);
        for (int i = 0; i < inventoryManager.playerSlotsBar; i++)
        {
            GameObject newSlot = Instantiate(prefabSlot,fastHands.transform);
           slots.Add(newSlot);
            if (inventoryManager.Inventory[i] != null)
            {
                    newSlot.name = $"[Slot[{i}]: {inventoryManager.Inventory[i].itemName}]";
                    Item instanc = inventoryManager.Inventory[i];
                    SlotObj slotScript =newSlot.GetComponent<SlotObj>();
                    slotScript.slotNuber.text = (i+1).ToString();
                    slotScript.icon.sprite = instanc.spriteIcon;
                    newSlot.GetComponent<UnityEngine.UI.Image>().SetNativeSize();
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
        inventoryManager.actualSlot = indice;
        inventoryManager.actualItem = inventoryManager.Inventory[indice -1];
    }
    public void ShowPlusStats()
    {
        for (int i = 0; i < statUis.Count; i++)
        {
            if (i <= 7)
            {
                if ( statUis[i].statsTab.plus != null)
                {
                    statUis[i].statsTab.plus.gameObject.SetActive(true);
                }else
                {
                    Debug.Log("Botão não encontrado!!");
                }
            }else
            {
                break;
            }
        }
    }
     public void HiddenPlusStats()
    {
        for (int i = 0; i < statUis.Count; i++)
        {
            if (i <= 7)
            {
                if ( statUis[i].statsTab.plus != null)
                {
                    statUis[i].statsTab.plus.gameObject.SetActive(false);
                }else
                {
                    Debug.Log("Botão não encontrado!!");
                }
            }else
            {
                break;
            }
        }
    }

}
