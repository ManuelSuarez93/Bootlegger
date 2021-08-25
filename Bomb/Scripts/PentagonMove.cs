using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonMove : MonoBehaviour
{
    [SerializeField] Transform t1;
    [SerializeField] Transform t2;

    Vector2 originalPos;

    private void Start()
    {
        originalPos = t1.position;
    }

    public void playerTouching()
    {
        StartCoroutine(move());
    }

    public void playerNot()
    {
        StopAllCoroutines();
        t1.position = originalPos;
    }

    IEnumerator move()
    {
        float timer = 0;
        while(timer < 2)
        {
            timer += Time.deltaTime;
            t1.position = Vector2.Lerp(t1.position, t2.position, timer/2);
            yield return null;
        }
    }
}
