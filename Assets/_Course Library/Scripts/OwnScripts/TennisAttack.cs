using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisAttack : MonoBehaviour
{
    [SerializeField] float health = 5f;
    [SerializeField] float dmgTaken = 1f;

    [SerializeField] private GameObject obj;



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Tennis_Racket"))
        {
            TakeDamage(dmgTaken);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tennis_Racket"))
        {
            TakeDamage(dmgTaken);
        }
    }

    

    public void TakeDamage(float dmg)
    {
        health = health - dmg;
        if(health <= 0)
        {
            Instantiate(obj, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
