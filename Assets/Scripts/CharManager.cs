using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public static CharManager Instance{get; private set;}
    public ClasseSo classSo;
    public List<Char> chars = new List<Char>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }else
        {
            Instance = this;
        }
    }
    public Char createChar(string name)
    {
         Char @char = new FactoryChar(classSo).Create(name);
         chars.Add(@char);
         Debug.Log(chars.Count);
         return @char;
         
    }

}
