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
    public FloatValue MaxHealth;
    public float Health;
    public string EnemyName;
    public int BaseAttack;
    public float MoveSpeed;

    private void Awake()
    {
        Health = MaxHealth.InitialValue;
    }

    private void TakeDamage(FloatValue damage)
    {
        Health -= damage.InitialValue;
        if(Health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D rigidbody2D, float knockTime, FloatValue damage)
    {
        StartCoroutine(KnockCo(rigidbody2D, knockTime));
        TakeDamage(damage);
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
