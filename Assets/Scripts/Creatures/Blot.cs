using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blot : Creature
{
    public Transform playerTransform;

    private float aggroRange = 5;
    private bool inAggroRange;
    private bool inFireAttackRange;
    private Vector2 movementVector;

    protected override void Update()
    {
        if (health > 0)
        {
            inAggroRange = (GetTransform().position - playerTransform.position).magnitude < aggroRange;
            inFireAttackRange = (GetTransform().position - playerTransform.position).magnitude < 2; //myWeapons[0].attackRange;

            if (inFireAttackRange)
            {
                movementVector = new Vector2((playerTransform.position - GetTransform().position).y, -(playerTransform.position - GetTransform().position).x);
                if(!isAttacking)
                {
                    isAttacking = true;
                    RangeAttack((RangeWeapon)myWeapons[0], playerTransform.position);
                }
            }
            else if (inAggroRange)
            {
                movementVector = playerTransform.position - GetTransform().position;
            }
            else
            {
                movementVector = new Vector2(0, 0);
            }

            StartMove(movementVector);
        }
        else
        {
            StartMove(new(0, 0));
        }
    }
}
