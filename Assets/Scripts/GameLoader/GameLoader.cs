using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public static GameLoader Instance{get; private set;}
    public RaritysSo itensRarityData;
    public chanceTypesSo chanceTypeItemData;
    public WeaponSo weaponData;
    public FoodSo foodData;

    void Awake()
    {
        RarityTable.init(itensRarityData);
        chanceTypeItem.init(chanceTypeItemData);
         if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
}
