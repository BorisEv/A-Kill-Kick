using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkeletonBoss : Creature
{
    public Transform playerTransform;

    private float aggroRange = 10;
    private bool inAggroRange;
    private bool inSwordAttackRange;
    private bool inSpearAttackRange;
    private Vector2 movementVector;
    
    protected override void Update()
    {
        if(health > 0)
        {
            inAggroRange = (GetTransform().position - playerTransform.position).magnitude < aggroRange;
            inSwordAttackRange = (GetTransform().position - playerTransform.position).magnitude < ((MeleeWeapon)myWeapons[0]).attackRange;
            inSpearAttackRange = (GetTransform().position - playerTransform.position).magnitude < ((MeleeWeapon)myWeapons[1]).attackRange + 1;

            if (inSwordAttackRange)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    MeleeAttack((MeleeWeapon)myWeapons[0]);
                }
                
                movementVector = playerTransform.position - GetTransform().position;
            }
            else if (inSpearAttackRange)
            {
                if (!isAttacking)
                {
                    isAttacking = true;
                    MeleeAttack((MeleeWeapon)myWeapons[1]);
                }

                movementVector = Vector2.zero;
            }
            else if (inAggroRange)
            {
                if (!isAttacking)
                {
                    movementVector = playerTransform.position - GetTransform().position;
                }
            }
            else
            {
                movementVector = Vector2.zero;
            }

            StartMove(movementVector);
        }
        else
        {
            StartMove(Vector2.zero);
        }
    }
}

