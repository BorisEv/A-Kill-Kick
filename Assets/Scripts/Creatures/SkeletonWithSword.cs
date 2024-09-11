using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkeletonWithSword : Creature
{
    private float aggroRange = 4;
    
    protected override void Update()
    {
        if(health > 0)
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

            StartMove(inputVector);

            if (!isAttacking)
            {
                Collider2D[] overlapedAttackRangeColliders = Physics2D.OverlapCircleAll(GetTransform().position, myWeapons[0].attackRange);
                foreach (Collider2D col in overlapedAttackRangeColliders)
                {
                    if (col.CompareTag("Player"))
                    {
                        myWeapons[0].Attack(animator, this);
                    }
                }
            }
        }
        else
        {
            StartMove(new(0,0));
        }

    }
}

