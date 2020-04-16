using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walking,
    attacking,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState CurrentState;

    public int Health;
    public string EnemyName;
    public int BaseAttack;
    public float MoveSpeed;

    public void Knock(Rigidbody2D rigidbody2D, float knockTime)
    {
        StartCoroutine(KnockCo(rigidbody2D, knockTime));
    }

    private IEnumerator KnockCo(Rigidbody2D rigidbody2D, float knockTime)
    {
        if (rigidbody2D != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2D.velocity = Vector2.zero;
            CurrentState = EnemyState.idle;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
