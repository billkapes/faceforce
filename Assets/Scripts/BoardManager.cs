using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject[] levels;
    public Transform Obs;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(levels[Random.Range(0, levels.Length)], Obs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
