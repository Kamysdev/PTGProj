using TMPro;
using UnityEngine;

public class GunUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText;

    public void UpdateAmmoCount(int currentAmmo, int maxAmmo)
    {
        ammoText.text = $"{currentAmmo}/{maxAmmo}";
    }
}
