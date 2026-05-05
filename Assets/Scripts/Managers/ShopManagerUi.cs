using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerUi : MonoBehaviour
{
    public ShopManager shopManager;
    public GameObject itemIndPrefab;
    public Scrollbar ShopScrolbar;
    public VerticalLayoutGroup LayoutGroup;
    public List<PrefabItemMenu> prefabsUi = new List<PrefabItemMenu>();
    public List<GameObject> buttons = new List<GameObject>();
    void Start()
    {
        shopManager = ShopManager.Instance;
        addToLayoutGroup();
        shopManager.orgList(ShopManager.Filters.Abc,FiltersScript.Mode.ascending);
       
    }
    public void OrganizeItens()
    {   
       for (int i = 0; i < shopManager.itens.Count; i++)
       {
            Item item = shopManager.itens[i];
            var ui = prefabsUi.Find(x=> x.item == item);
            ui.transform.SetSiblingIndex(i);
       }
    }
    public void addToLayoutGroup()
    {
   
        foreach (Item it in ShopManager.Instance.itens)
        {
            GameObject newObj =  Instantiate(itemIndPrefab,LayoutGroup.transform);
            TMP_Text textName = newObj.GetComponent<PrefabItemMenu>().textItem;
            textName.text = $"{it.itemName} seesh da silva silva";
            string prefix = lists.prefixos[Random.Range(0,lists.prefixos.Count)];
            string sufix = lists.sufixos[Random.Range(0,lists.sufixos.Count)];
            if (it is weapon sword)
            {
                sword.setByArangeStats();sword.aplyRarityMulti();
                sword.itemName = prefix + sword.itemName + sufix;
                textName.text = $"{sword.itemName} {sword.damage:f2} | Rng: {sword.range:f2}";
                
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
    public void updateUiButtons(Button actualClick,FiltersScript.Mode filterMode)
    {
        foreach (GameObject obj in buttons)
        {
            FiltersScript filtersScript = obj.GetComponent<FiltersScript>();
            Image iconArrow =  filtersScript.iconArrow;
            if (obj != actualClick.gameObject)
            {
                shopManager.changeCurrentButton(filtersScript);
                iconArrow.transform.rotation = Quaternion.Euler(0,0,180);
                iconArrow.color = Color.green;
                obj.GetComponent<TMP_Text>().color = new Color32(0xEC, 0xEA, 0xEA, 0x52);
                iconArrow.gameObject.SetActive(false);
            }
            else if(obj == actualClick.gameObject)
            {
                if (filterMode == FiltersScript.Mode.ascending)
                {
                       iconArrow.transform.rotation = Quaternion.Euler(0,0,180);
                        iconArrow.color = Color.green;
                }else
                {
                    iconArrow.transform.rotation = Quaternion.Euler(0,0,0);
                     iconArrow.color = Color.red;
                }
                obj.GetComponent<TMP_Text>().color = Color.white;
                iconArrow.gameObject.SetActive(true);
            }
        }
    }
}
