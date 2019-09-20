using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;
    private int currentWeaponIndex;

    void Start()
    {
        currentWeaponIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
    }

    private void TurnOnSelectedWeapon(int index)
    {
        if (currentWeaponIndex != index)
        {
            if (currentWeaponIndex != -1)
                weapons[currentWeaponIndex].gameObject.SetActive(false);
            weapons[index].gameObject.SetActive(true);
            currentWeaponIndex = index;
        }
    }

    public WeaponHandler GetCurrentWeapon()
    {
        return weapons[currentWeaponIndex];
    }
}
