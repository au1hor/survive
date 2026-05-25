using System.Collections;

using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class lifeheartIssues : MonoBehaviour
{
    public float speed;
    inventoryManager inventoryManager;
    public Sprite[]sprs;
    public TMP_Text lifeNumber;
    public Image heart;

    public void Start()
    {
        heartAni();
    }
    IEnumerator heartAni()
    {
        int i = 0;
        while (true)
        {
            heart.sprite = sprs[i];
            i++;
            if (i > sprs.Length)
            {
                i = 0;
            }
            yield return new WaitForSeconds(speed);
        }
        
    }
    
}
