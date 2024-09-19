using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkeletonWithSpear : Creature
{
    public Transform playerTransform;

    private float aggroRange = 6;
    private bool inAggroRange;
    private bool inSpearAttackRange;
    private Vector2 inputVector;

    protected override void Update()
    {
        if(health > 0)
        {
            inAggroRange = (GetTransform().position - playerTransform.position).magnitude < aggroRange;
            inSpearAttackRange = (GetTransform().position - playerTransform.position).magnitude < myWeapons[0].attackRange + 1;

            if (inSpearAttackRange)
            {
                if(!isAttacking) {
                    isAttacking = true;
                    myWeapons[0].Attack(animator, this);
                }

                inputVector = new Vector2(0, 0);
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
            StartMove(new(0,0));
        }

    }
}

