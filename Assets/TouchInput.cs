using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TouchDirection
{
    left, right, up, down, none, idle
}

public class TouchInput : MonoBehaviour
{
    public bool gotTouch;
    public Vector2 startPos, direction;
    public TouchDirection touchResult;

    // Start is called before the first frame update
    void Start()
    {
        touchResult = TouchDirection.idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
               
                case TouchPhase.Began:
                    
                    startPos = touch.position;
                   
                    break;

                
                case TouchPhase.Moved:
                    
                    direction = touch.position - startPos;
                    
                    break;

                case TouchPhase.Ended:

                    if (direction.magnitude < 50)
                    {
                        touchResult = TouchDirection.none;
                    }
                    else if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        
                        if (direction.x > 0)
                        {
                            touchResult = TouchDirection.right;
                        }
                        else
                        {
                            touchResult = TouchDirection.left;
                        }
                    }
                    else
                    {
                        if (direction.y > 0)
                        {
                            touchResult = TouchDirection.up;
                        }
                        else
                        {
                            touchResult = TouchDirection.down;
                        }
                    }

                    gotTouch = true;

                    break;
            }
        }
    }
}
