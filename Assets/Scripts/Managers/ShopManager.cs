using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance{get; private set;}
    public VerticalLayoutGroup LayoutGroup;
    public GameObject itemIndPrefab;
    public List<Item> itens = new List<Item>();
    public List<PrefabItemMenu> prefabsUi = new List<PrefabItemMenu>();
    public enum Filters
    {
        Abc,
        Cost,
        Type

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
          
            newObj.GetComponent<PrefabItemMenu>().textCost.text = $"{it.cost} R$";
            newObj.GetComponent<PrefabItemMenu>().item = it;
            prefabsUi.Add(newObj.GetComponent<PrefabItemMenu>());
        }
    }
    public void CreateRandomItens()
    {
        string[] names = {
    "Akira",
    "Hikari","Ren","Yuki","Haruto","Sora","Takumi","Kaito","Ryu","Kenji","Daichi","Shiro","Kazuki","Hiroshi","Takeshi","Isamu","Naoki","Rei","Itsuki","Hayato","Aoi","Hinata","Sakura","Emi","Yuna","Mizuki","Akane","Hana","Kaori","Rin","Nanami","Ayaka","Chika","Asuka","Hotaru","Nozomi","Kohana","Sumire","Mai","Natsuki"
};
        for (int i = 0; i < 10; i++)
        {
            Item NewItem = new Sword(names[Random.Range(0,names.Length)],2,3,1,Random.Range(100,9999));
            itens.Add(NewItem);
        }
    }
    public void OrganizeItens(Filters filter)
    {
         switch (filter)
        {
            case Filters.Abc:
            itens = itens.OrderBy(i=>i.itemName).ToList();
            break;
            case Filters.Cost:
            itens = itens.OrderByDescending(i => i.cost).ToList();
            break;
            case Filters.Type:
            
            break;
        }
       for (int i = 0; i < itens.Count; i++)
       {
            Item item = itens[i];
            var ui = prefabsUi.Find(x=> x.item == item);
            ui.transform.SetSiblingIndex(i);
       }
    }
    public void FilterClik(Button button)
    {
        var filter = button.GetComponent<FiltersScript>().filter;
        OrganizeItens(filter);
    }
    
}
