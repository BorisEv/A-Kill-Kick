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

    public void SpawnWeapon(Vector2 spawnPos, Weapon weapon)
    {
        GameObject a;
        switch (weapon.name)
        {
            case "Sword":
                {
                    a = Instantiate(pfSword);
                    break;
                }
            case "Spear":
                {
                    a = Instantiate(pfSpear);
                    break;
                }
            default:
                {
                    a = Instantiate(pfSword);
                    break;
                }
        }
        a.transform.position = spawnPos;
    }
}
