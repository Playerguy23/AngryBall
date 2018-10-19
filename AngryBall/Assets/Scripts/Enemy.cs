using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float health = 4;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.relativeVelocity.magnitude > health) {
            Die();
        }
        
    }

    private void Die() {
        Destroy(gameObject);
    }
}
