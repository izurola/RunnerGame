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
            transform.Rotate(40*Time.deltaTime,40*Time.deltaTime,40*Time.deltaTime);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name=="Player")
            {
                Destroy(gameObject);
                PlayerManager.Coins++;
            }
        }
}