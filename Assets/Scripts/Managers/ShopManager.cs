using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance{get; private set;}
    public List<Item> itens = new List<Item>();
    public List<weapon> swordSos;
    public ShopManagerUi shopManagerUi;
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
    }
    public void CreateRandomItens()
    {
       for (int i = 0; i < 300; i++)
       {
        Item newItem =new Item("Novo Item");
        newItem.setType(true);
      
        Item item = newItem.typeItem switch
        {
            TypeItem.weapon => new weapon(newItem.itemName),
            _ => new Food(newItem.itemName)
        };
        item.itemName = $"{item.typeItem.ToString().FirstCharacterToUpper()}";
        item.setRarity(true);
        itens.Add(item);
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
        FiltersScript.Mode.ascending => query.ToList(),
        FiltersScript.Mode.descending => query.Reverse().ToList(),
        _ => itens
       };
       shopManagerUi.OrganizeItens();
    }
    public void FilterClik(Button button)
    {
        FiltersScript filtersScript = button.gameObject.GetComponent<FiltersScript>();
        filtersScript.ind ++;
        switch (filtersScript.ind)
        {
            case 1:
            filtersScript.actualMode =   FiltersScript.Mode.ascending;
            break;
            case 2:
            filtersScript.actualMode =   FiltersScript.Mode.descending;
            filtersScript.ind =0;
            break;
        }
        shopManagerUi.updateUiButtons(button,filtersScript.actualMode);
        var filter = filtersScript.filter;
        orgList(filter,filtersScript.actualMode);
        shopManagerUi.OrganizeItens();
    }
    public void changeCurrentButton(FiltersScript filtersScript)
    {
        filtersScript.ind = 0;
    }
    
}
