using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance{get; private set;}
    public VerticalLayoutGroup LayoutGroup;
    public GameObject itemIndPrefab;
    public Scrollbar ShopScrolbar;
    public List<Item> itens = new List<Item>();
    public List<weapon> swordSos;
    public List<PrefabItemMenu> prefabsUi = new List<PrefabItemMenu>();
    public enum Filters
    {
        Abc,
        Cost,
        Type,
        Rarity

    }
    public Dictionary<TypeItem, float> chanceRandomItens = new Dictionary<TypeItem, float>()
    {
        {TypeItem.consumable, 25f},
        {TypeItem.tools,25f},
        {TypeItem.acessories,15f},
        {TypeItem.armor, 15f},
        {TypeItem.weapon,20f}
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
    void Start()
    {
        CreateRandomItens();
        addToLayoutGroup();
        orgList(Filters.Abc,FiltersScript.Mode.ascending);
        ShopScrolbar.value = 0.99f;
       
    }
    public void addToLayoutGroup()
    {
        foreach (Item it in itens)
        {
            GameObject newObj =  Instantiate(itemIndPrefab,LayoutGroup.transform);
            TMP_Text textName = newObj.GetComponent<PrefabItemMenu>().textItem;
            textName.text = $"{it.itemName} seesh da silva silva";
            if (it is weapon sword)
            {
                Debug.Log("s");
                textName.text = $"{sword.itemName} sesh da espada da silva Dmg: {sword.damage} | Rng: {sword.range} | AttSpd: {sword.attackSpeed}";
            }
            newObj.name = it.rarity.ToString();
            newObj.GetComponent<PrefabItemMenu>().textCost.text = $"{it.cost:f1} R$";
            newObj.GetComponent<PrefabItemMenu>().item = it;
            newObj.GetComponent<PrefabItemMenu>().textRarity.text = it.rarity.ToString().FirstCharacterToUpper();
            prefabsUi.Add(newObj.GetComponent<PrefabItemMenu>());
        }
    }
    public void CreateRandomItens()
    {
        TypeItem typeItem = TypeItem.consumable;
        for (int i = 0; i < 300; i++)
        {
             float total = 0;
        foreach (var item in chanceRandomItens)
        {
            total += item.Value;
        }
        float accm = 0;
        foreach (var item in chanceRandomItens)
        {
            accm += Random.Range(0,total);
            if (accm > item.Value)
            {
                typeItem = item.Key;
                return;
            }
        }
        string nome = lists.nomes[Random.Range(0,lists.nomes.Count)];
        Item query = typeItem switch
        {
           
            _ => new Food(nome,Random.Range(0,2.3f),Random.Range(0,64),new Vector2(0,120)),
        };
        }
       
    }
  
    public void OrganizeItens()
    {   
       for (int i = 0; i < itens.Count; i++)
       {
            Item item = itens[i];
            var ui = prefabsUi.Find(x=> x.item == item);
            ui.transform.SetSiblingIndex(i);
       }
    }
    public void orgList(Filters filter,FiltersScript.Mode mode)
    {
       IEnumerable<Item> query = filter switch
       {
         Filters.Abc => itens.OrderBy(i=> i.itemName),
         Filters.Cost => itens.OrderBy(i=> i.cost),
         Filters.Rarity => itens.OrderBy(i=> RarityTable.rarityItens[i.rarity]),  
         _ => itens
       };
       itens = mode switch
       {
        FiltersScript.Mode.disable => itens,
        FiltersScript.Mode.ascending => query.ToList(),
        FiltersScript.Mode.descending => query.Reverse().ToList()
       };
       OrganizeItens();
    }
    public void FilterClik(Button button)
    {
        FiltersScript filtersScript = button.gameObject.GetComponent<FiltersScript>();
        filtersScript.ind ++;
        switch (filtersScript.ind)
        {
            case 0:
            filtersScript.acualMode =   FiltersScript.Mode.disable;
            filtersScript.iconArrow.gameObject.SetActive(false);
            button.GetComponent<TMP_Text>().color = new Color32(0xEC, 0xEA, 0xEA, 0x52);;
            break;
            case 1:
            filtersScript.acualMode =   FiltersScript.Mode.ascending;
            filtersScript.iconArrow.gameObject.SetActive(true);
            filtersScript.iconArrow.gameObject.transform.rotation = Quaternion.Euler(0,0,180);
            filtersScript.iconArrow.GetComponent<Image>().color = Color.green;
            button.GetComponent<TMP_Text>().color = Color.white;
            break;
            case 2:
            filtersScript.acualMode =   FiltersScript.Mode.descending;
            filtersScript.iconArrow.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            filtersScript.iconArrow.GetComponent<Image>().color = Color.red;
            break;
            default:
            filtersScript.acualMode =   FiltersScript.Mode.disable;
            filtersScript.iconArrow.gameObject.SetActive(false);
            filtersScript.ind = 0;
            button.GetComponent<TMP_Text>().color = new Color32(0xEC, 0xEA, 0xEA, 0x52);;
            break;
        }
        var filter = filtersScript.filter;
        ShopScrolbar.value = 1;
        orgList(filter,filtersScript.acualMode);
        OrganizeItens();
    }
    
}
