using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Skeleton : Creature
{
    protected override void Update()
    {
        Vector2 inputVector = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        StartMove(inputVector);

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (myWeapons.Count > 0)
                {
                    StartAttack(myWeapons[0]);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myWeapons.Count > 1)
                {
                    StartAttack(myWeapons[1]);
                }
            }
        }
    }
}

