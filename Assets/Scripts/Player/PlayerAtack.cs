using System.Collections;
using UnityEngine;


public class PlayerAtack : MonoBehaviour
{
    public Sprite[] slashSpr;
    public GameObject atackPrefab;
    Coroutine animAtack;
    public void slashAtack()
    {

        GameObject slash = Instantiate(atackPrefab,transform);
        if (animAtack != null)
        {
            StopCoroutine(animAtack);
            return;
        }
        StartCoroutine(slashAnimation(slash));
    }
    
    public IEnumerator slashAnimation(GameObject slash)
    {
        slash.transform.rotation = Quaternion.Euler(0,0,Random.Range(-90,90));
        int ind = 0;
        while (ind < slashSpr.Length)
        {
            
            yield return new WaitForSeconds(0.03f);
            
            slash.GetComponent<SpriteRenderer>().sprite = slashSpr[ind];
            ind ++;
        }
        Destroy(slash,0.05f);
     
    }
}
