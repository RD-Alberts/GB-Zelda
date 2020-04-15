using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float Thrust; //knock back force
    
    public float KnockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemyRigidbody2D = other.GetComponent<Rigidbody2D>();
            if(enemyRigidbody2D != null)
            {
                enemyRigidbody2D.GetComponent<Enemy>().CurrentState = EnemyState.stagger;
                Vector2 difference =  enemyRigidbody2D.transform.position - transform.position;
                difference = difference.normalized * Thrust;
                enemyRigidbody2D.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemyRigidbody2D));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(KnockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().CurrentState = EnemyState.idle;
        }
    }
}
