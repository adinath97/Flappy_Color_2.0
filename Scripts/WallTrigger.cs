using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            Player.moveSpeed = 0f;
            Player.playerDead = true;
            GameManager.showEverything = true;
        }
        
   }
}
