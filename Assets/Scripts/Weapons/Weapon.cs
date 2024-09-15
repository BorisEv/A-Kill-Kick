using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public float damage;
    public float attackRange;
    public float attackSpeed;
    public Sprite sprite;
    //TODO public Collider2D hitBox;

    public void Attack(Animator animator, Creature attacker)
    {
        animator.SetTrigger(AnimationStrings.Attack);
        animator.SetFloat(AnimationStrings.AttackSpeed, attackSpeed);
        animator.SetTrigger(name);
        Collider2D [] overlapedColliders = Physics2D.OverlapCircleAll(attacker.GetTransform().position, attackRange);

        foreach (Collider2D col in overlapedColliders)
        {
            IDamageable damageable = col.GetComponent<IDamageable>();
            if (damageable != null && !damageable.Equals(attacker))
            {
                damageable.GetDamage(damage);
            }
        }

    }

}
