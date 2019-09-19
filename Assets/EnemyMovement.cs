using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EnemyMovement : MonoBehaviour
{
    public bool myTurn;
    Vector3 destination;
    bool foundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        destination = Vector3.left * 2f;
    }

    // Update is called once per frame
    void Update()
    {


        if (myTurn)
        {
            myTurn = false;
            transform.DOMove(destination, 0.44f).OnComplete(FinishMove).SetRelative();
            
            
        }
    }

    void FinishMove()
    {
        if (!foundPlayer)
        {
            //destination = transform.position + Vector3.right * 2f;
        }
        //TurnManager.Instance.EnemyDone();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            
            foundPlayer = true;
            //transform.rotation = Quaternion.LookRotation(destination, Vector3.up);
            destination = (other.transform.position - transform.position).normalized * 8f;
            
            GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            
        }

    }

}
