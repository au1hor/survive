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
    public List<PrefabItemMenu> prefabsUi = new List<PrefabItemMenu>();
    public enum Filters
    {
        Abc,
        Cost,
        Type,
        Rarity

    }
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
    }
    public void addToLayoutGroup()
    {
        foreach (Item it in itens)
        {
            GameObject newObj =  Instantiate(itemIndPrefab,LayoutGroup.transform);
            TMP_Text textName = newObj.GetComponent<PrefabItemMenu>().textItem;
            textName.text = $"{it.itemName} seesh da silva silva";
            if (it is Sword sword)
            {
                Debug.Log("s");
                textName.text = $"{sword.itemName} sesh da espada da silva Dmg: {sword.damage} | Rng: {sword.range} | AttSpd: {sword.attackSpeed}";
            }
            newObj.name = it.rarity.ToString();
            newObj.GetComponent<PrefabItemMenu>().textCost.text = $"{it.cost} R$";
            newObj.GetComponent<PrefabItemMenu>().item = it;
            newObj.GetComponent<PrefabItemMenu>().textRarity.text = it.rarity.ToString().FirstCharacterToUpper();
            prefabsUi.Add(newObj.GetComponent<PrefabItemMenu>());
        }
    }
    public void CreateRandomItens()
    {
        string[] names = {
            "Akira","Hikari","Ren","Yuki","Haruto","Sora","Takumi",
            "Kaito","Ryu","Kenji","Daichi","Shiro","Kazuki","Hiroshi",
            "Takeshi","Isamu","Naoki","Rei","Itsuki","Hayato","Aoi","Hinata",
            "Sakura","Emi","Yuna","Mizuki","Akane","Hana","Kaori","Rin","Nanami",
            "Ayaka","Chika","Asuka","Hotaru","Nozomi","Kohana","Sumire","Mai","Natsuki"
        };
        for (int i = 0; i < 300; i++)
        {
            Item NewItem = new Sword(names[Random.Range(0,names.Length)],2,3,1,Random.Range(100,9999));
            
            itens.Add(NewItem);
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
         Filters.Rarity => itens.OrderBy(i=> RarityTable.raridades[i.rarity]),  
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
            break;
            case 1:
            filtersScript.acualMode =   FiltersScript.Mode.ascending;
            break;
            case 2:
            filtersScript.acualMode =   FiltersScript.Mode.descending;
            break;
            default:
            filtersScript.acualMode =   FiltersScript.Mode.disable;
            filtersScript.ind = 0;
            break;
        }
        var filter = filtersScript.filter;
        ShopScrolbar.value = 1;
        orgList(filter,filtersScript.acualMode);
        OrganizeItens();
    }
    
}
