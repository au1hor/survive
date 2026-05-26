

using System;
using System.Collections;
using System.Security;
using Unity.Mathematics;
using UnityEngine;

public class enemieBehaviour : MonoBehaviour
{
    public states currentState = states.chilling;
    SpriteRenderer spriteRenderer;
    Color currentColor = Color.white;
    enemieStats enemieStats;
    enemieUi enemieUi;
    public GameObject player;
    public float magnDist;
    public Rigidbody2D rb;
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        enemieStats = this.GetComponent<enemieStats>();
        enemieUi = GetComponent<enemieUi>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        changingState(states.chilling);
        InvokeRepeating(nameof(checkEnemies),0,0.2f);
       
    }
    public void Update()
    {
       move();
    }
    public void move()
    {
         if ( currentState == states.chasing && player != null)
        {
            Vector2 dist = (player.transform.position-  transform.position ).normalized;
            Debug.Log(dist);
            rb.linearVelocity =dist* enemieStats.speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        enemieUi.changeSprMove(rb.linearVelocity);     
    }
    public void checkEnemies()
    {    if (player == null)
        {
            changingState(states.chilling);
        }
        RaycastHit2D[] enemies = Physics2D.CircleCastAll(transform.position,enemieStats.vision,Vector2.zero);
        if (enemies.Length >0 && enemies[0].collider != null)
        {
            foreach (RaycastHit2D item in enemies)
            {
                if (item.collider.tag == "Player")
                {
                    player = item.collider.gameObject;
                    magnDist = (this.gameObject.transform.position - player.transform.position).magnitude;
                    if (magnDist <= enemieStats.reach && currentState!=states.attacking)
                    {
                        changingState(states.attacking);
                        return;
                    }else if (magnDist >enemieStats.reach)
                    {
                        changingState(states.chasing);
                          return;
                    }
                }
                player = null;
            }
        }
    }
    public enum states
    {
        chilling,
        walkChiling,
        chasing,
        attacking,
        hitted
    }
    public void changingState(states state)
    {
        Action changing = state switch // eu acho que n precisa disso mais achei dahora
        {
            states.chilling => toChill,
            states.walkChiling => toWalk,
            states.chasing =>toChase,
            states.attacking => toAtack,
            states.hitted => toHitted,
            _ => toChill

        };
        changing();
    }
    public void toChill()
    {
        currentState = states.chilling;
        //currentColor = spriteRenderer.color = Color.blue;
        rb.linearVelocity = Vector2.zero;
    }
    public void toWalk()
    {   
        currentState = states.walkChiling;
        //currentColor = spriteRenderer.color = Color.yellowGreen;
    }
    public void toChase()
    { 
        currentState = states.chasing;    
       // currentColor = spriteRenderer.color = Color.orangeRed;
    }
    Coroutine AttackAni;
    public void toAtack()
    { 
        currentState = states.attacking;    
        //currentColor = spriteRenderer.color = Color.purple;
        if (AttackAni != null)
        {
            StopCoroutine(AttackAni);
        }
        AttackAni = StartCoroutine(attackingAni());
    }
    IEnumerator attackingAni()
    {
        DamageInfo atac = new DamageInfo();
        atac.attacker = this.gameObject;
        atac.damage = 10;
        atac.critical = false;

        player.GetComponent<PlayerStats>().TakeDamage(atac);
        yield return null;
    }
    Coroutine getHittedAni;
    public void toHitted()
    {
        currentState = states.hitted;
        if (getHittedAni != null)
        {
            StopCoroutine(getHittedAni);
        }
        getHittedAni = StartCoroutine(getHitted());
    }
    IEnumerator getHitted()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = currentColor;

    }
}
