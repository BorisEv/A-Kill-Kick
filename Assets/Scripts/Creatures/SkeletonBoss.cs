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
    private Vector2 inputVector;
    
    protected override void Update()
    {
        if(health > 0)
        {
            inAggroRange = (GetTransform().position - playerTransform.position).magnitude < aggroRange;
            inSwordAttackRange = (GetTransform().position - playerTransform.position).magnitude < myWeapons[0].attackRange;
            inSpearAttackRange = (GetTransform().position - playerTransform.position).magnitude < myWeapons[1].attackRange + 1;

            if (!isAttacking)
            {
                if (inSwordAttackRange)
                {
                    isAttacking = true;
                    myWeapons[0].Attack(animator, this);
                    inputVector = playerTransform.position - GetTransform().position;
                }
                else if (inSpearAttackRange)
                {
                    isAttacking = true;
                    myWeapons[1].Attack(animator, this);
                    inputVector = GetTransform().position - playerTransform.position;
                }
                else if (inAggroRange)
                {
                    inputVector = playerTransform.position - GetTransform().position;
                }
                else
                {
                    inputVector = new Vector2(0, 0);
                }
            }

            StartMove(inputVector);
        }
        else
        {
            StartMove(new(0,0));
        }

    }
}

