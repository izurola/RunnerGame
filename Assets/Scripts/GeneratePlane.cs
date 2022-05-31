using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlane : MonoBehaviour
{
    public GameObject ground;
    Vector3 pos = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        int n = Random.Range(6,11);
        for(int i=0;i<n;i++)
        {
            drawPlane(i*20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawPlane(int posPlane)
    {
        pos.z=posPlane;
        Instantiate(ground,pos,transform.rotation);
    }
}
