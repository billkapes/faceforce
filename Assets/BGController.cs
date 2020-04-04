﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.DOOffset(Vector2.one, 1).SetLoops(-1, LoopType.Restart).SetEase(Ease.OutCubic);
        //GetComponent<MeshRenderer>().material.DOColor(Color.grey, 1).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
