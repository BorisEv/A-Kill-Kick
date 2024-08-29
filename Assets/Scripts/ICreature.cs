using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{
    public void StartMove(Vector2 direction);

    public void StartAttack(Weapon weapon);

}
