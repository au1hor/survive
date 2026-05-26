using System.Collections;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Start()
    {
    
    }
    public void FixedUpdate()
    {
       chasePlayer();
    }
    public void chasePlayer()
    {   
        
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = player.transform.position;
        targetPos.z = -10;

        this.transform.position = Vector3.Lerp(startPos,targetPos,speed * Time.fixedDeltaTime);
    }
    
}
