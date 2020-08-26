using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsSpawn : MonoBehaviour
{
    public GameObject[] Obs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var ob in Obs)
        {
            ob.transform.Translate(new Vector3(Random.Range(-2, 2), Random.Range(-1, 1), 0));
            if (Random.Range(0, 2) > 0)
            {
                ob.transform.Rotate(Vector3.forward, 90);

            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
