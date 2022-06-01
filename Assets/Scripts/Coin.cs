using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(40*Time.deltaTime,0,0);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name=="Player")
            {
                // PlayerManager.winRound=true;
                Destroy(gameObject);
                PlayerManager.Coins++;
            }
        }
}