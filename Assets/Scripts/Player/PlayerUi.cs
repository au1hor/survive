using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
    public static PlayerUi Instance{get; private set;}
    public Canvas canvas;
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
