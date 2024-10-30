using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage; // ATTACK
    public float speed;
    public Vector3 target;  // can be creature, can be point? only in range projectiles?
    public Creature attacker;

    protected Vector3 movementDirection;
    public Collider2D hitBox;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        hitBox = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        transform.position = transform.position + speed * Time.deltaTime * movementDirection;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ContactFilter2D filter = new();

        List<Collider2D> overlapedColliders = new();
        Physics2D.OverlapCollider(hitBox, filter, overlapedColliders);


        foreach (Collider2D col in overlapedColliders)
        {
            IDamageable damageable = col.GetComponent<IDamageable>();
            if (damageable != null && !damageable.Equals(attacker))
            {
                damageable.GetDamage(damage);
                Destroy(gameObject);
            }
        }     
    }
}

