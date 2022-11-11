using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag == "Enemy"){
            Destroy(collision.gameObject);
            AudioManager.instance.Play("EnemyDestroyed");
            Destroy(gameObject); 
        }
        if(collision.tag == "Bounds"){
            Destroy(gameObject); 
        }
    }
    
}
