using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public bool myTurn;
    public Vector2 myVelocity;
    public GameObject jet, hair;
    public int currentThrust;
    public Slider thrustSlider;
    public float moveDuration = 0.44f;

    
    // Start is called before the first frame update
    void Start()
    {
        myVelocity = Vector2.zero;
        jet.SetActive(false);
        currentThrust = 1;
        thrustSlider.value = currentThrust;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, myVelocity * hit.distance, Color.white);

        if (Input.anyKeyDown && myTurn)
        {
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                HandleMovement(new Vector2(-1f, 0f));
            
            } else
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                HandleMovement(new Vector2(1f, 0f));

            } else
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                HandleMovement(new Vector2(0f, 1f));
                
            } else
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                HandleMovement(new Vector2(0f, -1f));
                
            } else

            if (Input.GetKeyDown(KeyCode.Space))
            {
                HandleMovement(new Vector2(0f, 0f));

                
 


            }


        }
    }

    private void HandleMovement(Vector2 vel)
    {
        myTurn = false;
        if (currentThrust >= 1 && vel != Vector2.zero)
        {
            jet.transform.localPosition = new Vector3(-vel.x, -vel.y, 0.1f);
            jet.transform.localScale = new Vector3(currentThrust, currentThrust, jet.transform.localScale.z);
            jet.SetActive(true);
        }

        GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);

        
        myVelocity.Set(myVelocity.x + vel.x * currentThrust, myVelocity.y + vel.y * currentThrust);

        if (vel == Vector2.zero)
        {
            currentThrust = Mathf.Clamp(currentThrust + 1, 1, 3);
            //thrustSlider.value = currentThrust;

            DOTween.To(() => thrustSlider.value, x => thrustSlider.value = x, currentThrust, moveDuration);

        }
        else
        {
            currentThrust = 0;
            //currentThrust = Mathf.Clamp(currentThrust - 1, 0, 3);
            //thrustSlider.value = currentThrust;

            DOTween.To(() => thrustSlider.value, x => thrustSlider.value = x, currentThrust, moveDuration);

        }


        RaycastHit hit;

        if (Physics.Raycast(transform.position, myVelocity, out hit, myVelocity.magnitude))
        {
            print("Found an object - distance: " + hit.distance);
            transform.DOMove((hit.point), moveDuration, false).OnComplete(FinishMove);
            myVelocity = Vector3.zero;
           
        } else
            transform.DOMove(transform.position + new Vector3(myVelocity.x, myVelocity.y, 0f), moveDuration, false).OnComplete(FinishMove);

        hair.transform.localScale = Vector3.one * myVelocity.magnitude / 2f;


    }

    private void FinishMove()
    {
        jet.SetActive(false);
        jet.transform.localScale = new Vector3(1f, 1f, jet.transform.localScale.z);
        GetComponent<LineRenderer>().SetPosition(1, myVelocity);
        TurnManager.Instance.PlayerDone();

    }

    void PlayersTurn()
    {
        myTurn = true;
    }

}
