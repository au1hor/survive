using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Button textIconBnt;
    public Button invFullBtn;
    public GameObject screenLog;
    public GameObject screenInvChar;
    public List<spriteImport> sprites = new List<spriteImport>();
   [Serializable]
    public struct spriteImport
    {
        public string name;
        public Sprite spr;
    }
    public screen screenActual = screen.charInv;
    public enum screen
    {
        chat,
        charInv
    }
    void Start()
    {
        screenActual = screen.chat;

    }
    public Sprite getSpriteByName(string name)
    {
        foreach (var entry in sprites)
        {
            if (entry.name == name)
            {
                return entry.spr;
            }
        }
        return null;
    }
    public void changeChatIcon()
    {
        if (screenActual != screen.chat)
        {
            textIconBnt.GetComponent<Image>().sprite = getSpriteByName("chatFull");
            invFullBtn.GetComponent<Image>().sprite = getSpriteByName("Inv");
            screenInvChar.gameObject.SetActive(false);
            screenLog.gameObject.SetActive(true);
            screenActual = screen.chat;
        }
    }
     public void changeInvCharIcon()
    {
        Debug.Log("Pressed");
        if (screenActual != screen.charInv)
        {
            invFullBtn.GetComponent<Image>().sprite = getSpriteByName("InvFull");
            textIconBnt.GetComponent<Image>().sprite = getSpriteByName("chat");
            screenInvChar.gameObject.SetActive(true);
            screenLog.gameObject.SetActive(false);
            screenActual = screen.charInv;
        }
        Debug.Log("dont funfa");
    }
    

}
