using System.Collections;
using Unity.Burst.Intrinsics;
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
    public GameObject right;
    public GameObject mid;
    public GameObject left;
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
        if (AniChangeNotice != null)
        {
            StopCoroutine(AniChangeNotice);
        }
        AniChangeNotice = StartCoroutine(AniChange(index));
    }
    IEnumerator AniChange(int index)
    {
        float tempo = 0;
        actualIndex = index;
        Vector3 MidPos = mid.transform.position;
        Vector3[] startsPos = new Vector3[notices.Length];
        while (tempo <= Duration)
        {
            Vector3 side = left.transform.position;
            tempo += Time.deltaTime;
            var t = tempo/Duration;
            for (int i = 0; i < notices.Length; i++)
            {
                startsPos[i] = notices[i].transform.position;
            }
            for (int i = 0; i < notices.Length; i++)
            {
                if (i == actualIndex)
                {
                    notices[i].transform.position = Vector3.Lerp(startsPos[i],MidPos,t);
                }
                else
                {
                     if (i > actualIndex)
                    {
                        side = left.transform.position;
                    }else
                    {
                        side = right.transform.position;
                    }
                    if (notices[i].transform.position != side )
                    {
                        notices[i].transform.position = Vector3.Lerp(startsPos[i],side,t);
                    }
                      yield return null;
                }
            }
        }
    }
}
