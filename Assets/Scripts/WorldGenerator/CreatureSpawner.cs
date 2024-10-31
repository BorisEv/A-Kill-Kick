using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject pfSkeletonWithSword;
    public GameObject pfSkeletonWithSpear;
    public GameObject pfSkeletonBoss;
    public GameObject pfBlot;
    public Transform playerTransform;

    public static CreatureSpawner Instanse { get; private set; }

    public void Awake()
    {
        Instanse = this;
    }
    public void SpawnCreature(Vector2 spawnPos, string creatureName)
    {
        GameObject creatureObject;
        switch (creatureName)
        {
            case CreatureNames.SkeletonWithSword:
                {
                    creatureObject = Instantiate(pfSkeletonWithSword);
                    SkeletonWithSword skeleton = creatureObject.GetComponent<SkeletonWithSword>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }
            case CreatureNames.SkeletonWithSpear:
                {
                    creatureObject = Instantiate(pfSkeletonWithSpear);
                    SkeletonWithSpear skeleton = creatureObject.GetComponent<SkeletonWithSpear>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }
            case CreatureNames.SkeletonBoss:
                {
                    creatureObject = Instantiate(pfSkeletonBoss);
                    SkeletonBoss skeleton = creatureObject.GetComponent<SkeletonBoss>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }

            case CreatureNames.Blot:
                {
                    creatureObject = Instantiate(pfBlot);
                    Blot blot = creatureObject.GetComponent<Blot>();
                    blot.playerTransform = playerTransform;
                    break;
                }
            default:
                {
                    creatureObject = null;
                    break;
                }
        }
        creatureObject.transform.position = spawnPos;
    }
}
