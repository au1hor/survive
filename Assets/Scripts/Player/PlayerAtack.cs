using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D[] sesh = Physics2D.CircleCastAll(mousePos,3f,Vector2.zero);
        int minDist = 0;
        float currentDist = Mathf.Infinity; 
        for (int i = 0; i < sesh.Length; i++)
        {   
            if (sesh[i].collider.tag != "Player" && sesh[i].collider.tag != null)
            {   
                GameObject obj = sesh[i].collider.gameObject;
                float dist = (mousePos - (Vector2)obj.transform.position).magnitude;
                if (dist < currentDist)
                {
                    currentDist = dist;
                    minDist = i;
                }
            }
        }
        if (sesh.Length == 0 || sesh[minDist].collider.gameObject.tag == "Player" )
        {
            return null;
        }
        return sesh[minDist].collider.gameObject;
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
