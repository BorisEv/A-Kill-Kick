using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Player : Creature
{
    [SerializeField] private UIInventory uiInventory;
    [SerializeField] private TextMeshProUGUI bottomHintTextMesh;
    public Camera camera;

    public void AddWeapon(Weapon weapon)
    {
        myWeapons.Add(weapon);
        uiInventory.SetWeapon(myWeapons.Count - 1, weapon.inventorySprite);
    }

    protected override void Start()
    {
        bottomHintTextMesh.enabled = false;
    }

    protected override void Update()
    {
        Vector2 inputVector = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane));

        StartMove(inputVector);

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (myWeapons.Count > 0)
                {
                    if (myWeapons[0] is MeleeWeapon meleeWeapon)
                    {
                        MeleeAttack(meleeWeapon);
                    }
                    else if (myWeapons[0] is RangeWeapon rangeWeapon)
                    {
                        
                        RangeAttack(rangeWeapon, mousePosition);
                    }
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myWeapons.Count > 1)
                {
                    if (myWeapons[1] is MeleeWeapon meleeWeapon)
                    {
                        MeleeAttack(meleeWeapon);
                    }
                    else if (myWeapons[1] is RangeWeapon rangeWeapon)
                    {
                        RangeAttack(rangeWeapon, mousePosition);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            bottomHintTextMesh.enabled = true;
            WeaponManager weaponManager = collision.gameObject.GetComponent<WeaponManager>();
            bottomHintTextMesh.text = $@"Press ""F"" to pick up the {weaponManager.weapon.name}";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            bottomHintTextMesh.enabled = false;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                WeaponManager weaponManager = collision.gameObject.GetComponent<WeaponManager>();
                AddWeapon(weaponManager.weapon);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
