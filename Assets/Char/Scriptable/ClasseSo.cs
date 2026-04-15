using UnityEngine;

[CreateAssetMenu(fileName = "ClasseSo", menuName = "Scriptable Objects/ClasseSo")]
public class ClasseSo : ScriptableObject
{
  public enum raceTypeEnum
    {
        Human,
        Goblin,
        Half_Human,
        Orc,
        Elf
    
    };

    public raceTypeEnum raceType;
    public FloatRange health;
    public FloatRange damage;
    public FloatRange speed;
    public FloatRange attackSpeed;
}
