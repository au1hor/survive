using System;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    public static CharManager Instance{get; private set;}
    public ClasseSo classSo;
    public invCharManager invCharManager;
    List<Char> chars = new List<Char>();
    public List<CharView> charsView = new List<CharView>();
    [Serializable]
    public struct CharView
    {
        public Char @char;
        public string name;
    }
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
         Char newChar = new FactoryChar(classSo).Create(name);
         chars.Add(newChar);
         charsView.Add(new CharView{@char = newChar, name = name});
         invCharManager.addCardChar(newChar);
         return newChar;
         
    }

}
