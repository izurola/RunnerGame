using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlane : MonoBehaviour
{
    public GameObject ground;
    public GameObject ending;
    public GameObject []obstacle;
    Vector3 pos = new Vector3(0,0,0);
    Vector3 posForHole = new Vector3(0,0,0);
    Vector3 posForCaps = new Vector3(0,1,0);
    Vector3 posForCube = new Vector3(0,0.5f,0);
    Vector3 posForHeadObs = new Vector3(0,2.5f,0);
    Vector3 posForEnding = new Vector3(0,0.01f,0);
    public int n;
    private int previousLine=0;
    // Start is called before the first frame update
    void Start()
    {
        n = Random.Range(6,11+PlayerManager.Levels/10);
        for(int i=0;i<n;i++)
        {
            drawPlane(i);
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
        pos.z=-20;
        Instantiate(ground,pos,transform.rotation);
        if(i==0)
        {
            int beginningPoint=-7;
            Vector3 pos1 = posForCube;
            for(int j=0;j<7;j+=2)
            {
                pos1.z=beginningPoint+j;
                Instantiate(obstacle[4],pos1,transform.rotation);
            }
        }
        else if(i==n-1)
        {
            int endingPoint=(n-1)*20+9;
            posForEnding.z=endingPoint;
            Instantiate(ending,posForEnding,transform.rotation);
        }
        else 
        {
            for(int k=0;k<2;k++)
            {
                //obstacle garah magadlal 3/7
                //1 esvel 2 uyd coin dangaara garna
                int a= Random.Range(1,8);
                int lineNum,obs;
                float line=0;
                Vector3 poss;
                if(a>3)
                {
                    int obsPerLine = Random.Range(1,3);
                    for(int j=0;j<obsPerLine;j++)
                    {
                        lineNum = Random.Range(-1,2);
                        obs = Random.Range(0,4);
                        while(lineNum==previousLine)
                        {
                            lineNum=Random.Range(-1,2);
                        }
                        previousLine=lineNum;
                        line=lineNum*2.5f;
                        if(obs==3)
                        {
                            poss = posForHeadObs;
                        }
                        else if(obs == 1)
                        {
                            poss = posForCube;
                        }
                        else if(obs==0)
                        {
                            poss = posForCaps;
                        }
                        else 
                        {
                            poss = posForHole;
                        }
                        poss.x=line;
                        if(k==0)
                        {
                            poss.z=(i*20)-5;
                        }
                        else 
                        {
                            poss.z=(i*20)+5;
                        }
                        Instantiate(obstacle[obs],poss,transform.rotation);
                    }
                }
                else 
                {
                    lineNum = Random.Range(-1,2);
                    line=lineNum*2.5f;
                    int coinPerSpawn = Random.Range(2,5);
                    poss = posForCube;
                    poss.x=line;
                    if(k==0)
                        poss.z=(i*20)-6;
                    else 
                        poss.z=(i*20)+6;
                    
                    while(coinPerSpawn>0)
                    {
                        Instantiate(obstacle[4],poss,transform.rotation);
                        poss.z+=2;
                        coinPerSpawn--;
                    }
                }
            }
        }
    }
}
