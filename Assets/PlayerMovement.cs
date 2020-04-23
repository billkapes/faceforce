using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public bool myTurn, coastPressed;
    public Vector2 myVelocity;
    public GameObject jet, hair;
    public int currentThrust;
    public Slider thrustSlider;
    public float moveDuration = 0.44f;
    public Button up, down, left, right;
    
    TouchInput touchInput;

    
    // Start is called before the first frame update
    void Start()
    {
        myVelocity = Vector2.zero;
        jet.SetActive(false);
        currentThrust = 1;
        thrustSlider.value = currentThrust;
    }

    void Awake()
    {
        touchInput = GetComponent<TouchInput>();
    }

    public void CoastPressed()
    {
        coastPressed = true;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, myVelocity * hit.distance, Color.white);

        if ( (Input.anyKeyDown || touchInput.gotTouch || coastPressed) && myTurn)
        {

            touchInput.gotTouch = false;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || touchInput.touchResult == TouchDirection.left)
            {
                HandleMovement(new Vector2(-1f, 0f));
            
            } else
            if (Input.GetKeyDown(KeyCode.RightArrow) || touchInput.touchResult == TouchDirection.right)
            {
                HandleMovement(new Vector2(1f, 0f));

            } else
            if (Input.GetKeyDown(KeyCode.UpArrow) || touchInput.touchResult == TouchDirection.up)
            {
                HandleMovement(new Vector2(0f, 1f));
                
            } else
            if (Input.GetKeyDown(KeyCode.DownArrow) || touchInput.touchResult == TouchDirection.down)
            {
                HandleMovement(new Vector2(0f, -1f));
                
            } else

            if (Input.GetKeyDown(KeyCode.Space) || touchInput.touchResult == TouchDirection.none || coastPressed)
            {
                HandleMovement(new Vector2(0f, 0f));


            }

            
            touchInput.touchResult = TouchDirection.idle;

        }

        coastPressed = false;
    }

    private void HandleMovement(Vector2 inputVel)
    {

        myTurn = false;

        if (currentThrust == 0f && inputVel != Vector2.zero)
            inputVel = Vector2.zero;

        GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);

        myVelocity.Set(myVelocity.x + inputVel.x * currentThrust, myVelocity.y + inputVel.y * currentThrust);

        SetJet(inputVel);

        TweenSlider(inputVel);


        if (Physics.Raycast(transform.position, myVelocity, out RaycastHit hit, myVelocity.magnitude))
        {
            print("Found an object - distance: " + hit.distance);
            Vector3 newPos = hit.point;
            newPos = Vector3.MoveTowards(newPos, transform.position, 0.5f);

            //Vector3 newPos = transform.position.normalized - hit.point;
            //Vector3 newPos = (hit.point - transform.position).normalized;

            //Vector3 newPos = Vector3.MoveTowards(hit.point, transform.position, 0.5f);
            newPos = new Vector3(Mathf.Round(newPos.x), Mathf.Round(newPos.y), 0f);

            transform.DOMove(newPos, moveDuration, false).OnComplete(FinishMove);
            myVelocity = Vector3.zero;

        }
        else
            transform.DOMove(transform.position + new Vector3(myVelocity.x, myVelocity.y, 0f), moveDuration, false).OnComplete(FinishMove);

        hair.transform.localScale = Vector3.one * myVelocity.magnitude / 2f;
        GetComponent<Animator>().SetTrigger("Moving");


    }

    private void SetJet(Vector2 vel)
    {
        if (currentThrust >= 1 && vel != Vector2.zero)
        {
            jet.transform.localPosition = new Vector3(-vel.x, -vel.y, 0.1f);
            jet.transform.localScale = new Vector3(currentThrust, currentThrust, jet.transform.localScale.z);
            jet.SetActive(true);
        }
    }

    private void TweenSlider(Vector2 vel)
    {
        if (vel == Vector2.zero)
        {
            currentThrust = Mathf.Clamp(currentThrust + 1, 1, 3);

            DOTween.To(() => thrustSlider.value, x => thrustSlider.value = x, currentThrust, moveDuration);
        }
        else
        {
            currentThrust = 0;

            DOTween.To(() => thrustSlider.value, x => thrustSlider.value = x, currentThrust, moveDuration);

        }
    }

    private void FinishMove()
    {
        jet.SetActive(false);
        jet.transform.localScale = new Vector3(1f, 1f, jet.transform.localScale.z);
        GetComponent<LineRenderer>().SetPosition(1, myVelocity);
        TurnManager.Instance.PlayerDone();
        GetComponent<Animator>().SetTrigger("Idle");

    }

    void PlayersTurn()
    {
        myTurn = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            //transform.DOShakePosition(0.1f);

        }
    }

}
