using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public static PlayerUi Instance{get; private set;}
    public Canvas canvas;
    public GameObject popUpDmg;
    public GameObject lvUpPopUp;


    void Awake()
    {
        if (Instance != null &&  Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
    public void LvUpPopUp()
    {
        GameObject popUp = Instantiate(lvUpPopUp,canvas.transform);
        Vector2 playerTOcanvas = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        popUp.transform.position = playerTOcanvas;
        StartCoroutine(PopAnimationGain(popUp));
        
    }
    public void HealPopUp()
    {
        
    }
    public void VampireAbsorb(Vector2 worldPos,float value)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        GameObject newObj = Instantiate(popUpDmg,canvas.transform);
        newObj.transform.position = screenPos;
        newObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100,100),500),ForceMode2D.Impulse);
        newObj.GetComponent<TMP_Text>().text = value.ToString("F1");
        Destroy(newObj,1f);
    
    }
    IEnumerator PopAnimationGain(GameObject gainPopUp)
    {
        Vector2 startPos= gainPopUp.transform.position;
        Vector2 target =  gainPopUp.transform.position += new Vector3(0,50);
        TMP_Text text = gainPopUp.GetComponent<TMP_Text>();
        float duration = 0.75f;
        float time = 0;
        while (duration >= time)
        {
            time += Time.deltaTime;
            text.alpha = Mathf.Lerp(1,0,time/duration);
            gainPopUp.transform.position = Vector2.Lerp(startPos,target,time/duration);
            yield return null;
        }
        Destroy(gainPopUp);        
    }
}
