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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
