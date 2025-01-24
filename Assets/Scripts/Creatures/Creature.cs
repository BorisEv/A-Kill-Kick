using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour, IAttackable
{
    [SerializeField] protected float health;

    [SerializeField] protected float speed;

    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected Animator animator;

    [SerializeField] protected List<Weapon> myWeapons;    

    protected Vector2 movementDirection;
    protected Vector2 lastMovementDirection;

    protected bool isAttacking;

    public Transform GetTransform()
    {
        return rb.transform;
    }

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    void FixedUpdate()
    {
        isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
        rb.MovePosition(rb.position + speed * Time.deltaTime * movementDirection);
        if(movementDirection != Vector2.zero)
        {
            lastMovementDirection = movementDirection;
        }
    }

    public void StartMove(Vector2 movementVector)
    {
        movementDirection.x = movementVector.normalized.x;
        movementDirection.y = movementVector.normalized.y;


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

    public void MeleeAttack(MeleeWeapon meleeWeapon)
    {
        animator.SetTrigger(AnimationStrings.Attack);
        animator.SetFloat(AnimationStrings.AttackSpeed, meleeWeapon.attackSpeed);
        animator.SetTrigger(meleeWeapon.name);

        Collider2D[] overlapedColliders = Physics2D.OverlapCircleAll(transform.position, meleeWeapon.attackRange);

        foreach (Collider2D col in overlapedColliders)
        {
            IAttackable attackable = col.GetComponent<IAttackable>();
            if (attackable != null && !attackable.Equals(this))
            {
                attackable.GetAttacked(meleeWeapon.attack);
            }
        }
    }

    public void RangeAttack(RangeWeapon rangeWeapon, Vector2 target)
    {
        animator.SetTrigger(AnimationStrings.Attack);
        animator.SetFloat(AnimationStrings.AttackSpeed, rangeWeapon.attackSpeed);
        animator.SetTrigger(rangeWeapon.name);

        GameObject projectileObj = Instantiate(rangeWeapon.pfProjectile);
        projectileObj.transform.position = transform.position;
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.attack = rangeWeapon.attack;
        projectile.target = target;
        projectile.attacker = this;
    }


    public void GetAttacked(Attack attack)
    {
        // GetDamage
        float fullDamage = 0;
        foreach (Damage damage in attack.damage)
        {
            fullDamage += damage.power; // TODO resistances here
        }
        if (health > 0)
        {
            if (health - fullDamage <= 0)
            {
                StartCoroutine(Die());
                health = 0;
            }
            else
            {
                StartCoroutine(GetDamageAnimation());
                health -= fullDamage;
            }
        }

        // Get status effects TODO
    }

    private IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private IEnumerator GetDamageAnimation()
    {
        float duration = 0.2f;
        float startTime;
        SpriteRenderer[] renderers = gameObject.GetComponents<SpriteRenderer>();


        startTime = Time.time;
        while (Time.time < startTime + (duration / 2))
        {
            foreach (SpriteRenderer rend in renderers)
            {
                Color clr = rend.material.color;
                Color newColor = new(clr.r, clr.g, clr.b, 1 - (Time.time - startTime) / (duration / 2));
                rend.material.SetColor("_Color", newColor);

            }
            yield return null;
        }

        while (Time.time < startTime + (duration))
        {
            foreach (SpriteRenderer rend in renderers)
            {
                Color clr = rend.material.color;
                Color newColor = new(clr.r, clr.g, clr.b, ((Time.time - startTime) - (duration / 2)) / (duration / 2));
                rend.material.SetColor("_Color", newColor);
            }
            yield return null;
        }
    }
}
