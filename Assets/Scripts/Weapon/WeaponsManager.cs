using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    public int currentWeaponIndex;

    public void SwitchWeapon(int index)
    {
        if (index == currentWeaponIndex)
            return;

        weapons[currentWeaponIndex].gameObject.SetActive(false);
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    public void Attack()
    {
        weapons[currentWeaponIndex].Attack();
    }
    public void StopAttack()
    {
        weapons[currentWeaponIndex].isFiring = false;
    }
    public void Reload()
    {
        weapons[currentWeaponIndex].Reload();
    }
}
