using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAtack : MonoBehaviour
{
    public Sprite[] RightAttackSprs;
    public Sprite[] LeftAttackSprs;
    public GameObject atackPrefab;
    public inventoryManager invManager;
    public float aniduration;
    Coroutine animAtack;
    public void normalAttack(int mouseButton)
    {
        if (invManager.actualItem is weapon)
        {
            GameObject enemie = searchForEnemies();
            if (enemie == null)
            {
                Debug.Log("Dont find any enemies");
                return;
            }
            if (mouseButton == 1)
            {
                GameObject rightAttack = Instantiate(atackPrefab,enemie.transform);
                if (animAtack != null)
                {
                    StopCoroutine(animAtack);
                    return;
                }
                RightAttackSprs = invManager.actualItem.Animation;
                StartCoroutine(RightAnimation(rightAttack));
                enemie.GetComponent<enemieStats>().changeLife(-10);
            }else if (mouseButton == 0)
            {
                Debug.Log("Ataque leve esquerdo");
            }
        }
        else
        {
            Debug.Log("Não é uma arma!!!!");
        }
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
    public IEnumerator RightAnimation(GameObject attack)
    {
        //  attack.transform.rotation = Quaternion.Euler(0,0,Random.Range(-90,90));
        int ind = 0;
        while (ind < RightAttackSprs.Length)
        {   
            yield return new WaitForSeconds(aniduration);
            if(attack == null)break;   
            attack.GetComponent<SpriteRenderer>().sprite = RightAttackSprs[ind];
            ind ++;
        }
        Destroy(attack,0.05f);
     
    }
}
