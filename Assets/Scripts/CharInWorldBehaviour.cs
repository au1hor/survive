using System.Collections;
using UnityEngine;

public class CharInWorldBehaviour : MonoBehaviour
{
    float duração = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartCoroutine(randomMove());
    }

    // Update is called once per frame
    IEnumerator randomMove()
    {
        while (true)
        {
            if (Random.value < 0.3)
            {
                yield return new WaitForSeconds(Random.Range(0,5f));
            }
            Vector3 startPos = transform.position;
            Vector3 targetPost = getRandomPos();
            duração = Random.Range(1,5f);
            float tempo = 0;
            while (tempo < duração)
            {
                tempo += Time.deltaTime;
                float t = tempo / duração;
                t = Mathf.SmoothStep(0,1,t);
                transform.position = Vector3.Lerp(startPos,targetPost,t);
                yield return null;
            }
            transform.position = targetPost;
        }
    }
    public Vector3 getRandomPos(float range = 0)
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        if (range ==0)
        {
            range =Random.Range(2,10);

        }
        return transform.position + new Vector3(dir.x,dir.y,0) * range;
    }
}
