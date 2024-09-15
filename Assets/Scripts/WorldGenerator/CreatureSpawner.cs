using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject pfSkeletonWithSword;
    public GameObject pfSkeletonWithSpear;
    public GameObject pfSkeletonBoss;
    public Transform playerTransform;

    public static CreatureSpawner Instanse { get; private set; }

    public void Awake()
    {
        Instanse = this;
    }
    public void SpawnCreature(Vector2 spawnPos, string creatureName)
    {
        GameObject a;
        switch (creatureName)
        {
            case CreatureNames.SkeletonWithSword:
                {
                    a = Instantiate(pfSkeletonWithSword);
                    SkeletonWithSword skeleton = a.GetComponent<SkeletonWithSword>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }
            case CreatureNames.SkeletonWithSpear:
                {
                    a = Instantiate(pfSkeletonWithSpear);
                    SkeletonWithSpear skeleton = a.GetComponent<SkeletonWithSpear>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }
            case CreatureNames.SkeletonBoss:
                {
                    a = Instantiate(pfSkeletonBoss);
                    SkeletonBoss skeleton = a.GetComponent<SkeletonBoss>();
                    skeleton.playerTransform = playerTransform;
                    break;
                }
            default:
                {
                    a = null;
                    break;
                }
        }
        a.transform.position = spawnPos;
    }
}
