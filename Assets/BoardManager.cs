using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[] upperLefts;
    public Transform upperLeft;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(upperLefts[Random.Range(0, upperLefts.Length)], upperLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
