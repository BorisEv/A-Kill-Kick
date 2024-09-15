using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private List<Weapon> allWeapons;
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        SpawnWeapons();
        SpawnSkeletons();
    }

    private void SpawnWeapons()
    {
        Vector2 swordPosition = new(Random.Range(0, 5), Random.Range(0, 5));
        Vector2 spearPosition = new(Random.Range(0, 5), Random.Range(0, 5));

        WeaponSpawner.Instanse.SpawnWeapon(swordPosition, WeaponNames.Sword);
        WeaponSpawner.Instanse.SpawnWeapon(spearPosition, WeaponNames.Spear);
    }

    private void SpawnSkeletons()
    {
        Vector2 skeletonWithSwordPosition = new(15, 15);
        Vector2 skeletonWithSpearPosition = new(10, 10);
        Vector2 skeletonBossPosition = new(5, 5);

        CreatureSpawner.Instanse.SpawnCreature(skeletonWithSwordPosition, CreatureNames.SkeletonWithSword);
        CreatureSpawner.Instanse.SpawnCreature(skeletonWithSpearPosition, CreatureNames.SkeletonWithSpear);
        CreatureSpawner.Instanse.SpawnCreature(skeletonBossPosition, CreatureNames.SkeletonBoss);
    }

    void Update()
    {
        
    }
}
