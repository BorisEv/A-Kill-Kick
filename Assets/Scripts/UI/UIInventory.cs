using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<Image> weaponsImages = new();

    public Sprite sword;
    public void SetWeapon(int weaponNumber, Sprite weapon)
    {
        weaponsImages[weaponNumber].sprite = weapon;
        weaponsImages[weaponNumber].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //UIInventory stores player (or player weapons/Inventory) and updates the weaponImages each frame according to the weapons
    }
}
