using System.Collections.Generic;
using System.Linq;
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
    List<string> nomes = new List<string>()
{
    // Masculinos
    "Akira", "Ren", "Haruto", "Kazuki", "Ryu",
    "Takumi", "Hiroshi", "Daichi", "Kaito", "Sora",
    "Kenji", "Tatsuya", "Shin", "Yuto", "Masato",

    // Femininos
    "Aiko", "Yuki", "Sakura", "Hana", "Emi",
    "Rin", "Akane", "Hikari", "Mei", "Natsumi",
    "Kaori", "Ayumi", "Rika", "Nozomi", "Misaki",

    // Samurai / fortes
    "Kenshin", "Raiden", "Takeshi", "Isamu", "Hayato",
    "Jiro", "Nobunaga", "Yukimura", "Musashi", "Shingen",

    // Dark / melancólicos
    "Kuro", "Yoru", "Rei", "Itsuki", "Kage",
    "Shiro", "Renji", "Akira",

    // Suaves / artísticos
    "Sora", "Hikari", "Yume", "Haru", "Aoi", "Nagi"
};
    public void Sort(string name)
    {
        if (name == "" || name.Length <= 0 || name == "RANDOM".ToLower() )
        {
            name = nomes[Random.Range(0,nomes.Count)];
        }
       Char  @char = CharManager.Instance.createChar(name);
       AdicionarItem(@char.TextLog()); //vai enviar a mensagem dentro do character pra função do log
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
