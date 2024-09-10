using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour, IDamageable
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

    public void StartMove(Vector2 inputVector)
    {
        movementDirection.x = inputVector.x;
        movementDirection.y = inputVector.y;

        if (movementDirection.x == 0 && movementDirection.y == 0)
        {
            animator.SetBool(AnimationStrings.IsMoving, false);
        }
        else
        {
            animator.SetBool(AnimationStrings.IsMoving, true);
            animator.SetFloat(AnimationStrings.MoveX, movementDirection.x);
            animator.SetFloat(AnimationStrings.MoveY, movementDirection.y);
            if (!isAttacking)
            {
                animator.SetFloat(AnimationStrings.LastMoveX, movementDirection.x);
                animator.SetFloat(AnimationStrings.LastMoveY, movementDirection.y);
            }
        }
    }

    public void StartAttack(Weapon weapon)
    {
        weapon.Attack(animator, this);
    }

    public void GetDamage(float damage)
    {
        if (health > 0)
        {
            if (health - damage <= 0)
            {
                StartCoroutine(Die());
                health = 0;
            }
            else
            {
                StartCoroutine(GetDamage());
                health -= damage;
            }
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private IEnumerator GetDamage()
    {
        float duration = 0.2f;
        float startTime = Time.time;
        SpriteRenderer[] renderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

        while (Time.time < startTime + (duration/2))
        {
            foreach (SpriteRenderer rend in renderers)
            {
                Color clr = rend.material.color;
                Color newColor = new(clr.r, clr.g, clr.b, clr.a - (Time.deltaTime / (duration / 2)));
                rend.material.SetColor("_Color", newColor);
                
            }
            yield return null;
        }

        while (Time.time < startTime + (duration))
        {
            foreach (SpriteRenderer rend in renderers)
            {
                Color clr = rend.material.color;
                Color newColor = new(clr.r, clr.g, clr.b, clr.a + (Time.deltaTime / (duration / 2)));
                rend.material.SetColor("_Color", newColor);
            }
            yield return null;
        }
    }
}
