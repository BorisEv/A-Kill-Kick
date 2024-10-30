using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Windows;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public abstract class Weapon : ScriptableObject
{
    public float damage;
    public float attackSpeed; //cooldown?
    public Sprite inventorySprite;
}
