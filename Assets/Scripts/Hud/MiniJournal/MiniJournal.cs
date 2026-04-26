using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MiniJournal : MonoBehaviour
{
    public GameObject firstNotice;
    public GameObject secondNotice;
    public GameObject thirdNotice;
    //arrays
    public GameObject[] notices;
    public GameObject[] balls;
    // balls
    public GameObject firstBall;
    public GameObject MidBall;
    public GameObject LastBall;
    //pos 
    public Vector2 right;
    public Vector2 left;
    // currents 
    
    public int actualIndex;
    //pivo change
    public Transform Pivot;
    // corrotine
    Coroutine AniChangeNotice;
    // setCustom
    public float Duration;
    // sprites
    public Sprite emptyBall;
    public Sprite fullBall;
    void Start()
    {
        actualIndex = 1;
        notices = new GameObject[]{secondNotice,firstNotice,thirdNotice};
        balls = new GameObject[]{firstBall,MidBall,LastBall};
        right = secondNotice.transform.position;
        left = thirdNotice.transform.position;
    }
    public void changeCurrentNotice(int index)
    {
       
        if (index != actualIndex)
        {
            balls[index].GetComponent<Image>().sprite = fullBall;
            balls[actualIndex].GetComponent<Image>().sprite = emptyBall;
            switch (index)
            {
                case 0:
                ChangingNotice(firstNotice,0);
              
                break;
                case 1:
                ChangingNotice(secondNotice,1);
                break;
                case 2:
                ChangingNotice(thirdNotice,2);
                break;
            }
        }
    }
    public void ChangingNotice(GameObject Notice,int index)
    {
        /*GameObject temp = sides[0];
        sides[0] = Notice;
        sides[actualIndex] = temp; // {0,1,3} {3,1,0}
        */
        if (AniChangeNotice != null)
        {
            StopCoroutine(AniChangeNotice);
        }
        AniChangeNotice = StartCoroutine(AniChange(index));
    }
    IEnumerator AniChange(int index)
    {
        float tempo = 0;
        notices[index].transform.position = notices[actualIndex].transform.position;
        while (tempo <= Duration)
        {
            tempo ++;
            
            for (int i = 0; i < notices.Length; i++)
            {
                Debug.Log(i);
                if (i > index)
                {
                    notices[i].transform.position = left;
                }
                else if (i < index)
                {
                    notices[i].transform.position = right;
                }
            }
            actualIndex = index;
            yield return null;
        }
       
    }
  
   
}
