using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed;
    public float jumpSpeed;
    private float gravity=-20;
    private int lane = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed+=PlayerManager.Levels/10;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.GameStarted)
        {
            return;
        }
        if(GeneratePlane.endingPoint<=transform.position.z)
        {
            PlayerManager.winRound=true;
        }
        direction.z=speed;
        controller.Move(direction*Time.deltaTime);
        
        direction.y+=gravity*Time.deltaTime;

        if(TouchControl.swipedRight)
        {
            if(lane<2)
            {
                lane++;
            }
        }
        if(TouchControl.swipedLeft)
        {
            if(lane>0)
            {
                lane--;
            }
        }
        if(TouchControl.swipedUp)
        {
            if(controller.isGrounded)
            direction.y=jumpSpeed;
        }
        if(TouchControl.swipedDown)
        {
            StartCoroutine(sliding());
        }
        Vector3 targetPosition = transform.position.z*transform.forward+transform.position.y*transform.up;
        if(lane==0)
        {
            targetPosition+=Vector3.left*(float)2.5;
        }
        else if(lane==2)
        {
            targetPosition+=Vector3.right*(float)2.5;
        }
        transform.position=targetPosition;      
    }
    IEnumerator sliding()
    {
        Vector3 temp = new Vector3(1,0.5f,1);
        Vector3 temp1 = transform.localScale;
        transform.localScale=temp;
        gravity=-40;
        yield return new WaitForSecondsRealtime(0.8f);
        transform.localScale=temp1;
        gravity=-20;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = true;
        }
        if(hit.transform.tag == "Finish")
        {
            PlayerManager.winRound = true;   
        }
    }
}
