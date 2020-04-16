using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float Thrust; //knock back force
    public float KnockTime;
    public FloatValue PlayerDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("breakable"))
        {
            other.GetComponent<Pot>().Smash();
        }

        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hitRigidbody2D = other.GetComponent<Rigidbody2D>();
            if(hitRigidbody2D != null)
            {
                //calculating the knockback distance 
                Vector2 difference =  hitRigidbody2D.transform.position - transform.position;
                difference = difference.normalized * Thrust;
                hitRigidbody2D.AddForce(difference, ForceMode2D.Impulse);

                //the knockback for enemies
                if(other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    hitRigidbody2D.GetComponent<Enemy>().CurrentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hitRigidbody2D, KnockTime , PlayerDamage);
                }
                //the knockback for the player
                if(other.gameObject.CompareTag("Player"))
                {
                    hitRigidbody2D.GetComponent<PlayerMovement>().CurrentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(KnockTime);
                }
            }
        }
    }
}
