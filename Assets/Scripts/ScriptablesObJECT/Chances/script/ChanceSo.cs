using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "typeItens", menuName = "Scriptable Objects/typeItens")]
public class chanceTypesSo : ScriptableObject
{
    public List<TypeItem> typesItem;
    public List<float> Chance;
}
