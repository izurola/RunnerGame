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
    // private int level=0;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z=speed;
        controller.Move(direction*Time.deltaTime);
        
        direction.y+=gravity*Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(lane<2)
            {
                lane++;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(lane>0)
            {
                lane--;
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(controller.isGrounded)
            direction.y=jumpSpeed;
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = false;
        }
    }
}
