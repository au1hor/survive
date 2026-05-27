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
        StartCoroutine(heartAni());
    }
    IEnumerator heartAni()
    {
        int i = 0;
        while (true)
        {
             if (i + 1 > sprs.Length)
            {
                i = 0;
            }
                heart.sprite = sprs[i];
                i++;
            
            yield return new WaitForSeconds(speed);
        }
        
    }
    
}
