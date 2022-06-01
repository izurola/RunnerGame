using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchControl : MonoBehaviour
{
    public const float MAX_SWIPE_TIME = 0.5f; 

// Factor of the screen width that we consider a swipe
// 0.17 works well for portrait mode 16:9 phone
public const float MIN_SWIPE_DISTANCE = 0.17f;

public static bool swipedRight = false;
public static bool swipedLeft = false;
public static bool swipedUp = false;
public static bool swipedDown = false;
static bool swiped;


public bool debugWithArrowKeys = true;


public delegate void OnSwipe();
public static event OnSwipe swipeListeners;



Vector2 startPos;
float startTime;

public void Update()
{
	swiped = false;
	swipedRight = false;
	swipedLeft = false;
	swipedUp = false;
	swipedDown = false;

	if(Input.touches.Length > 0)
	{
		Touch t = Input.GetTouch(0);
		if(t.phase == TouchPhase.Began)
		{
			startPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);
			startTime = Time.time;
		}
		if(t.phase == TouchPhase.Ended)
		{
			if (Time.time - startTime > MAX_SWIPE_TIME) 
				return;

			Vector2 endPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);

			Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

			if (swipe.magnitude < MIN_SWIPE_DISTANCE) 
				return;

			if (Mathf.Abs (swipe.x) > Mathf.Abs (swipe.y)) { 
				if (swipe.x > 0) {
					swiped = swipedRight = true;
                    Debug.Log("right");
				}
				else {
					swiped = swipedLeft = true;
                    Debug.Log("left");
				}
			}
			else { 
				if (swipe.y > 0) {
					swiped = swipedUp = true;
				}
				else {
					swiped = swipedDown = true;
				}
			}
		}
	}

	if (debugWithArrowKeys) {
		swipedDown = swipedDown || Input.GetKeyDown (KeyCode.DownArrow);
		swipedUp = swipedUp|| Input.GetKeyDown (KeyCode.UpArrow);
		swipedRight = swipedRight || Input.GetKeyDown (KeyCode.RightArrow);
		swipedLeft = swipedLeft || Input.GetKeyDown (KeyCode.LeftArrow);
		swiped = swipedDown || swipedLeft || swipedRight || swipedUp;
	}

	if (swiped)
    {
		if (swipeListeners != null)
		{
			swipeListeners();
		}

	}
}
        
}
