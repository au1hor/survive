using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public InputActionReference move;
    public PlayerStats stats;
    public Rigidbody2D rb;
    public SpriteRenderer playerSpr;
    public Sprite[] runAnimation;
    public Sprite[] idle;
    public float duration;
    Coroutine animation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = PlayerStats.instance;
        StartCoroutine(Animove());
       
    }
    public void FixedUpdate()
    {
        Vector2 vMove =move.action.ReadValue<Vector2>();
        moveInput(vMove * stats.stats[PlayerStats.StatType.SPD].value);
    }
    public void moveInput(Vector2 value)
    {
        rb.linearVelocity = value;
       
    }
    IEnumerator Animove()
    {
        int indice = 0;
        while (true)
        {    yield return new WaitForSeconds(duration);
             if (rb.linearVelocity == Vector2.zero)
             {
                playerSpr.sprite = idle[0];
                indice =0;
                  
             }else
             {
                playerSpr.sprite = runAnimation[indice];
                if (indice +1 >= runAnimation.Length)
                {
                    indice = 0;
                }else
                {
                    indice ++;
                }
             }
           
           
        }
    

        
    }
}
