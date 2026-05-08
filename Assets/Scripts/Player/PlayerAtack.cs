using System.Collections;
using UnityEngine;


public class PlayerAtack : MonoBehaviour
{
    public Sprite[] slashSpr;
    public GameObject atackPrefab;
    Coroutine animAtack;
    public void slashAtack()
    {
        GameObject enemie = searchForEnemies();
        if (enemie == null)
        {
            Debug.Log("Dont find any enemies");
            return;
        }
        GameObject slash = Instantiate(atackPrefab,enemie.transform.position,Quaternion.identity);
        if (animAtack != null)
        {
            StopCoroutine(animAtack);
            return;
        }
        StartCoroutine(slashAnimation(slash));
        enemie.GetComponent<enemieStats>().changeLife(-10);
    }
    public GameObject searchForEnemies()
    {
        RaycastHit2D[] sesh = Physics2D.CircleCastAll(transform.position,10f,Vector2.zero);
        if (sesh[0].collider != null && sesh.Length != 0)
        {
            return sesh[0].collider.gameObject;
        }
        return null;
    }
    public IEnumerator slashAnimation(GameObject slash)
    {
        slash.transform.rotation = Quaternion.Euler(0,0,Random.Range(-90,90));
        int ind = 0;
        while (ind < slashSpr.Length)
        {   
            yield return new WaitForSeconds(0.05f);   
            slash.GetComponent<SpriteRenderer>().sprite = slashSpr[ind];
            ind ++;
        }
        Destroy(slash,0.05f);
     
    }
}
