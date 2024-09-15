using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject pfSword;
    public GameObject pfSpear;

    public static WeaponSpawner Instanse {  get; private set; }

    public void Awake()
    {
        Instanse = this;
    }

    public void SpawnWeapon(Vector2 spawnPos, string weaponName)
    {
        GameObject a;
        switch (weaponName)
        {
            case WeaponNames.Sword:
                {
                    a = Instantiate(pfSword);
                    break;
                }
            case WeaponNames.Spear:
                {
                    a = Instantiate(pfSpear);
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
