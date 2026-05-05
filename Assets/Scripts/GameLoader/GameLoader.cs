using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public RaritysSo itensRarityData;
    public chanceTypesSo chanceTypeItemData;
    public WeaponSo weaponData;
    public FoodSo foodData;

    void Awake()
    {
        RarityTable.init(itensRarityData);
        chanceTypeItem.init(chanceTypeItemData);
    }
}
