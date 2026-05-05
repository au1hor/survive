using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RaritysSo", menuName = "Scriptable Objects/RaritysSo")]
public class RaritysSo : ScriptableObject
{
    public List<Rarity> rarities;
    public List<float> Chances;
    public List<float> Multi;
}
