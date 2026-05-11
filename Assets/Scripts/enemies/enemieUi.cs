using TMPro;
using UnityEngine;

public class enemieUi : MonoBehaviour
{
    public Sprite[] sprites;
    public Transform mainCanvas;
    SpriteRenderer spriteRenderer;
    public GameObject popUpDmg;
  


    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
      
    }
    public void Update()
    {
        
    }
    public void changeSprMove(Vector2 dir)
    {
        if (dir.x < 0 && dir.y <0)
        {
            if (dir.x <= dir.y)
            {
                spriteRenderer.sprite = sprites[0];
                spriteRenderer.flipX = false;
            }else
            {
                 spriteRenderer.sprite = sprites[3];
            }
        }else if(dir.x >0 && dir.y >0)
        {
             if (dir.x >= dir.y)
            {
                spriteRenderer.sprite = sprites[0];
                spriteRenderer.flipX = true;
            }else
            {
                 spriteRenderer.sprite = sprites[1];
            }
        }else
        {
            spriteRenderer.sprite = sprites[2];
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }
    }
    public void damagePopUp(Vector2 worldPos,float value)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        GameObject newObj = Instantiate(popUpDmg,mainCanvas);
        newObj.transform.position = screenPos;
        newObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100,100),500),ForceMode2D.Impulse);
        newObj.GetComponent<TMP_Text>().text = value.ToString();
        Destroy(newObj,1f);
    }

}
