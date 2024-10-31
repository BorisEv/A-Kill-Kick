using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject pfSword;
    public GameObject pfSpear;
    public GameObject pfFire;

    public static WeaponSpawner Instanse {  get; private set; }

    public void Awake()
    {
        Instanse = this;
    }

    public void SpawnWeapon(Vector2 spawnPos, string weaponName)
    {
        GameObject weaponObject;
        switch (weaponName)
        {
            case WeaponNames.Sword:
                {
                    weaponObject = Instantiate(pfSword);
                    
                    break;
                }
            case WeaponNames.Spear:
                {
                    weaponObject = Instantiate(pfSpear);
                    break;
                }
            case WeaponNames.Fire:
                {
                    weaponObject = Instantiate(pfFire);
                    break;
                }
            default:
                {
                    weaponObject = null;
                    break;
                }
        }
        weaponObject.transform.position = spawnPos;
    }
}
