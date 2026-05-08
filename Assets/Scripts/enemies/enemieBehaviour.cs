

using System;
using System.Collections;
using System.Security;
using Unity.Mathematics;
using UnityEngine;

public class enemieBehaviour : MonoBehaviour
{
    states currentState = states.chilling;
    SpriteRenderer spriteRenderer;
    Color currentColor = Color.white;
    enemieStats enemieStats;
    public GameObject player;
    public float magnDist;
    Rigidbody2D rb;
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        enemieStats = this.GetComponent<enemieStats>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        changingState(states.chilling);
        InvokeRepeating(nameof(checkEnemies),0,0.5f);
       
    }
    public void Update()
    {
        if (magnDist <= enemieStats.vision && player != null)
        {
            Debug.Log(magnDist);
            Vector2 dist = (player.transform.position-  transform.position ).normalized;
            rb.linearVelocity =dist* enemieStats.speed;
        }
          
    }
    public void checkEnemies()
    {
        Debug.Log("Checkando");
        RaycastHit2D[] enemies = Physics2D.CircleCastAll(transform.position,enemieStats.vision,Vector2.zero);
        if (enemies.Length >0 && enemies[0].collider != null)
        {
            foreach (RaycastHit2D item in enemies)
            {
                if (item.collider.tag == "Player")
                {
                    player = item.collider.gameObject;
                    magnDist = (this.gameObject.transform.position - player.transform.position).magnitude;
                    changingState(states.chasing);
                    Debug.Log("Encontrado");
                }
            }
        }
    }
    public enum states
    {
        chilling,
        walkChiling,
        chasing,
        hitted
    }
    
    public void changingState(states state)
    {
        Action changing = state switch
        {
            states.chilling => toChill,
            states.walkChiling => toWalk,
            states.chasing =>toChase,
            states.hitted => toHitted,
            _ => toChill

        };
        changing();
    }
    public void toChill()
    {
      currentColor = spriteRenderer.color = Color.blue;
    }
    public void toWalk()
    {
         currentColor = spriteRenderer.color = Color.yellowGreen;
    }
    public void toChase()
    { 
        currentColor = spriteRenderer.color = Color.orangeRed;
    }
    Coroutine getHittedAni;
    public void toHitted()
    {
        
        if (getHittedAni != null)
        {
            StopCoroutine(getHittedAni);
        }
        getHittedAni = StartCoroutine(getHitted());
    }
    IEnumerator getHitted()
    {
        Debug.Log("tyetet");
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = currentColor;

    }
}
