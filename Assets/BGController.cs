using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGController : MonoBehaviour
{
    private readonly int[] xValues = {-3, -2, -1, 1, 2, 3};
    private readonly int[] yValues = {-3, -2, -1, 1, 2, 3};

    // Start is called before the first frame update
    void Start()
    {
        Invoke("MoveBG", 2);
        //GetComponent<MeshRenderer>().material.DOColor(Color.grey, 1).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveBG()
    {
        int x = xValues[Random.Range(0, xValues.Length)];
        int y = yValues[Random.Range(0, yValues.Length)];
        GetComponent<MeshRenderer>().material.DOOffset(new Vector2(x, y), 1.4f).SetEase(Ease.OutCubic).OnComplete(MoveBG);
        Debug.Log("" + x + y);
    }
}
