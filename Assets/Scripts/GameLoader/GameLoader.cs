using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public RaritysSo itensRarityData;

    void Awake()
    {
        RarityTable.init(itensRarityData);
    }
}
