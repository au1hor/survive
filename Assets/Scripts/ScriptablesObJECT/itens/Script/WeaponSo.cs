using UnityEngine;

[CreateAssetMenu(fileName ="WeaponSo", menuName ="Scriptable Objects/WeaponSo")]
public class WeaponSo: ItemSo
{
    public TypeItem typeItem = TypeItem.weapon;
    public TypeWeapons typeWeapon= TypeWeapons.sword;
    public string creatorName;
    public Vector2 RangeDamage;
    public Vector2 RangeRange;
    public Vector2 RangeBaseWeight;
    
}