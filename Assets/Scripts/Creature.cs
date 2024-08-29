using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour, IDamageable// TODO, ICreatureController
{
    [SerializeField] protected float health;

    [SerializeField] protected float speed;

    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected Animator animator;

    [SerializeField] protected List<Weapon> myWeapons;    

    protected Vector2 movementDirection;

    protected bool isAttacking;

    public Transform GetTransform()
    {
        return rb.transform;
    }

    protected virtual void Awake()
    {

    }

    protected virtual void Update()
    {

    }

    void FixedUpdate()
    {
        isAttacking = !animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            && !animator.GetCurrentAnimatorStateInfo(0).IsName("Move");
        //TODO when the weapon attack animation will be on different layer - we can simple the line above to "Attack" state
        rb.MovePosition(rb.position + movementDirection * speed * Time.deltaTime);
    }

    public void Damage(float damage)
    {
        if (health - damage <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            animator.SetTrigger("GetDamage");
        }
        health -= damage;
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
