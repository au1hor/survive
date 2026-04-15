using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public List<GameObject> Msgs = new List<GameObject>();
    public Transform content;
    public GameObject prefabText;
    public ScrollRect scrollRect;
    public ClasseSo testSo;

    public void Sort(string name)
    {
       Char @char = CharManager.Instance.createChar(name);
       AdicionarItem(@char.TextLog());
    }
    public void AdicionarItem(string text)
    {
        GameObject msg = Instantiate(prefabText, content);
        Msgs.Add(msg);
        msg.GetComponentInChildren<TMP_Text>().text = text;
        scrollRect.verticalNormalizedPosition = 0f;

    }
    public void clearAllMsg()
    {
        foreach (GameObject msg in Msgs)
        {
            Destroy(msg);
        }
        Msgs.Clear();
    }
}
