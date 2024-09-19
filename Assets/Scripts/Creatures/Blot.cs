using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blot : Creature
{
    public Transform playerTransform;

    private float aggroRange = 5;
    private bool inAggroRange;
    private bool inFireAttackRange;
    private Vector2 inputVector;

    protected override void Update()
    {
        if (health > 0)
        {
            inAggroRange = (GetTransform().position - playerTransform.position).magnitude < aggroRange;
            inFireAttackRange = (GetTransform().position - playerTransform.position).magnitude < myWeapons[0].attackRange;

            if (inFireAttackRange)
            {
                inputVector = new Vector2((playerTransform.position - GetTransform().position).y, -(playerTransform.position - GetTransform().position).x);
                if(!isAttacking)
                {
                    isAttacking = true;
                    myWeapons[0].Attack(animator, this);
                }
            }
            else if (inAggroRange)
            {
                inputVector = playerTransform.position - GetTransform().position;
            }
            else
            {
                inputVector = new Vector2(0, 0);
            }

            StartMove(inputVector);
        }
        else
        {
            StartMove(new(0, 0));
        }
    }
}
