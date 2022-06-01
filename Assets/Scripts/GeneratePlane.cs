using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlane : MonoBehaviour
{
    public GameObject ground;
    public GameObject []obstacle;
    Vector3 pos = new Vector3(0,0,0);
    Vector3 posForObs = new Vector3(0,1,0);
    Vector3 posForHeadObs = new Vector3(0,2.5f,0);
    public int n;
    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(6,11);
        for(int i=0;i<n;i++)
        {
            drawPlane(i);
        }
        for(int i=1;i<n-1;i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawObstacles(int posObs)
    {

    }
    void drawPlane(int i)
    {
        pos.z=i*20;
        Instantiate(ground,pos,transform.rotation);
        if(i==0)
        {
            int beginningPoint=-7;
            Vector3 pos1 = posForObs;
            for(int j=0;j<7;j+=2)
            {
                pos1.z=beginningPoint+j;
                Instantiate(obstacle[4],pos1,transform.rotation);
            }
        }
        if(i==n-1)
        {
            
        }
        int diss = 4;
        Vector3 poss1= posForObs;
        poss1.z=diss;
        Instantiate(obstacle[1],poss1,transform.rotation);
    }
}
