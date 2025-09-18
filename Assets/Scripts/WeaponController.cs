using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float rateOfFire = 3.0f;

    [SerializeField]
    private float bulletSpread = 0;

    private float nextShotTime = 0;
    private bool triggerHeld = false;

    void OnShoot(InputValue input)
    {
        triggerHeld = input.Get<float>() > 0.5f;
    }

    void Update()
    {
        if (Time.time > nextShotTime && triggerHeld)
        {
            //Debug.Log("Shoot!");
            float spread = Random.Range(-bulletSpread, bulletSpread);

            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(new Vector3(0, 0, spread));

            nextShotTime = Time.time + (1 / rateOfFire);
        }
    }
}
