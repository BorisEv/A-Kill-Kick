using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Creature
{
    [SerializeField] private UIInventory uiInventory;
    [SerializeField] private TextMeshProUGUI BottomHintTextMesh;

    public void AddWeapon(Weapon weapon)
    {
        myWeapons.Add(weapon);
        uiInventory.SetWeapon(myWeapons.Count - 1, weapon.sprite);
    }

    public void StartMove(Vector2 inputVector)
    {
        movementDirection.x = inputVector.x; 
        movementDirection.y = inputVector.y; 

        if (movementDirection.x == 0 && movementDirection.y == 0)
        {
            animator.SetBool(AnimationStrings.IsMooving, false);
        }
        else
        {
            animator.SetBool(AnimationStrings.IsMooving, true);
            animator.SetFloat(AnimationStrings.MoveX, movementDirection.x);
            animator.SetFloat(AnimationStrings.MoveY, movementDirection.y);
            if (!isAttacking)
            {
                animator.SetFloat(AnimationStrings.LastMoveX, movementDirection.x);
                animator.SetFloat(AnimationStrings.LastMoveY, movementDirection.y);
            }
        }
    }

    public void StartAttack(Weapon weapon)
    {
        weapon.Attack(animator, this);
    }

    void Start()
    {
        BottomHintTextMesh.enabled = false;
    }

    protected override void Update()
    {
        Vector2 inputVector = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        StartMove(inputVector);

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (myWeapons.Count > 0)
                {
                    StartAttack(myWeapons[0]);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (myWeapons.Count > 1)
                {
                    StartAttack(myWeapons[1]);
                }     
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            BottomHintTextMesh.enabled = true;
            WeaponManager weaponManager = collision.gameObject.GetComponent<WeaponManager>();
            BottomHintTextMesh.text = $@"Press ""F"" to pick up the {weaponManager.weapon.name}";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            BottomHintTextMesh.enabled = false;
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
