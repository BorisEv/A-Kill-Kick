using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    void Start()
    {
        SpawnWeapons();
        SpawnSkeletons();
    }

    private void SpawnWeapons()
    {
        Vector2 swordPosition = new(Random.Range(0, 5), Random.Range(0, 5));
        Vector2 spearPosition = new(Random.Range(0, 5), Random.Range(0, 5));
        Vector2 firePosition = new(1, 1);

        WeaponSpawner.Instanse.SpawnWeapon(swordPosition, WeaponNames.Sword);
        WeaponSpawner.Instanse.SpawnWeapon(spearPosition, WeaponNames.Spear);
        WeaponSpawner.Instanse.SpawnWeapon(firePosition, WeaponNames.Fire);
    }

    private void SpawnSkeletons()
    {
        Vector2 skeletonWithSwordPosition = new(15, 15);
        Vector2 skeletonWithSpearPosition = new(10, 10);
        Vector2 skeletonBossPosition = new(12, 12);
        Vector2 blotPosition = new(-15, 0);

        CreatureSpawner.Instanse.SpawnCreature(skeletonWithSwordPosition, CreatureNames.SkeletonWithSword);
        CreatureSpawner.Instanse.SpawnCreature(skeletonWithSpearPosition, CreatureNames.SkeletonWithSpear);
        CreatureSpawner.Instanse.SpawnCreature(skeletonBossPosition, CreatureNames.SkeletonBoss);
        CreatureSpawner.Instanse.SpawnCreature(blotPosition, CreatureNames.Blot);
    }

    void Update()
    {
        
    }
}
