using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position-target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position+offset;
        targetPosition.x=0;
        transform.position=targetPosition;
    }
}
