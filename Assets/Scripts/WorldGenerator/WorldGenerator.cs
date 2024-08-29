using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private List<Weapon> allWeapons;

    void Start()
    {
        SpawnWeapons();
    }

    private void SpawnWeapons()
    {
        Vector2 swordPosition = new(Random.Range(0, 5), Random.Range(0, 5));
        Vector2 spearPosition = new(Random.Range(0, 5), Random.Range(0, 5));

        WeaponSpawner.Instanse.SpawnWeapon(swordPosition, allWeapons[0]);
        WeaponSpawner.Instanse.SpawnWeapon(spearPosition, allWeapons[1]);
    }

    void Update()
    {
        
    }
}
