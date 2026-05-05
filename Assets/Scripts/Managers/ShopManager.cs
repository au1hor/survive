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
    public GameLoader gameLoader;
    public List<PrefabItemMenu> prefabsUi = new List<PrefabItemMenu>();
    public enum Filters
    {
        Abc,
        Cost,
        Type,
        Rarity

    };
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
            string prefix = lists.prefixos[Random.Range(0,lists.prefixos.Count)];
            string sufix = lists.sufixos[Random.Range(0,lists.sufixos.Count)];
            if (it is weapon sword)
            {
                Debug.Log("s");
                textName.text = $"{prefix} {sword.itemName} {sufix} {sword.damage} | Rng: {sword.range}";
            }else if(it is Food food)
            {
                 textName.text = $"{food.itemName}x{food.amount} | saicety: {food.satiety}";
            }
            newObj.name = it.rarity.ToString();
            newObj.GetComponent<PrefabItemMenu>().textCost.text = $"{it.cost:f1} R$";
            newObj.GetComponent<PrefabItemMenu>().item = it;
            newObj.GetComponent<PrefabItemMenu>().textRarity.text = it.rarity.ToString().FirstCharacterToUpper();
            prefabsUi.Add(newObj.GetComponent<PrefabItemMenu>());
        }
    }
    public TypeItem sortType()
    {
        float total = 0;
        foreach (var item in chanceTypeItem.chanceItens)
        {
            total += item.Value;
        }
        float rng = Random.Range(0,total);
        float acc = 0;
        foreach (var item in chanceTypeItem.chanceItens)
        {
            acc += item.Value;
            if (rng > acc)
            {
                return item.Key;
            }
        }
        return TypeItem.weapon;
    }
    public void CreateRandomItens()
    {
       for (int i = 0; i < 300; i++)
       {
        string nome = lists.nomes[Random.Range(0,lists.nomes.Count)];
        TypeItem type = sortType();
        Item item = type switch
        {
            TypeItem.consumable => new Food(gameLoader.foodData.itemName,gameLoader.foodData.satiety,gameLoader.foodData.amount),
             _ =>  new weapon(gameLoader.weaponData.itemName,gameLoader.weaponData.RangeDamage,gameLoader.weaponData.RangeRange)
        };  
        itens.Add(item);
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
