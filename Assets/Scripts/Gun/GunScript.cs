using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GunShootingScript shootScript;
    [SerializeField] private GunLogic gunLogic;
    [SerializeField] private ReloadingScript reloadingScript;
    [SerializeField] private GunUIScript gunUIScript;

    [SerializeField][Range(1, 50)] private int maxAmmo;
    private int currentAmmo;

    private bool reloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
        gunUIScript.UpdateAmmoCount(currentAmmo, maxAmmo);
    }

    public void Shoot()
    {
        Debug.Log("[GunScript] Start shot");
        if (reloading) return;
        if (currentAmmo > 0) shootScript.PlayShootAnimation();
    }

    public void ReloadingStart()
    {
        if (reloading) return;
        reloading = true;
        reloadingScript.PlayReoadingAnimation();
    }

    public void ReloadingEnd()
    {
        reloading = false;
        currentAmmo = maxAmmo;
        gunUIScript.UpdateAmmoCount(currentAmmo, maxAmmo);
    }
    
    public void GunShot()
    {
        Debug.Log("Shoot in GunScript");
        gunLogic.Shoot();
        currentAmmo--;
        gunUIScript.UpdateAmmoCount(currentAmmo, maxAmmo);
    }
}
