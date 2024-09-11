using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkeletonWithSpear : Creature
{
    private float aggroRange = 5;
    
    protected override void Update()
    {
        if(health > 0)
        {
            if (!isAttacking)
            {
                Vector2 inputVector = new(0, 0);
                Collider2D[] overlapedAggroRangeColliders = Physics2D.OverlapCircleAll(GetTransform().position, aggroRange);
                foreach (Collider2D col in overlapedAggroRangeColliders)
                {
                    if (col.CompareTag("Player"))
                    {
                        inputVector = col.transform.position - GetTransform().position;
                    }
                }

                Collider2D[] overlapedAttackRangeColliders = Physics2D.OverlapCircleAll(GetTransform().position, myWeapons[0].attackRange + 0.2f);
                foreach (Collider2D col in overlapedAttackRangeColliders)
                {
                    if (col.CompareTag("Player"))
                    {
                        myWeapons[0].Attack(animator, this);
                        inputVector = new(0, 0);
                    }
                }
                StartMove(inputVector);
            }
        }
        else
        {
            StartMove(new(0,0));
        }

    }
}

