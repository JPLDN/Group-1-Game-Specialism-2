using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public float defaultFireRate = 0.15f;
    public float fireRate = 0.15f;

    private float nextFireTime = 0f;
    private bool spreadShotEnabled = false;
    private bool isFireRateBoosted = false;

    private void Start()
    {
        fireRate = defaultFireRate;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Debug.Log("Shooting! Spread Shot Enabled: " + spreadShotEnabled);

        if (spreadShotEnabled)
        {
            Debug.Log("Spread shot active! Shooting 3 bullets.");

           
            FireBullet(shootingPoint.forward);
            FireBullet(Quaternion.Euler(0, 30, 0) * shootingPoint.forward);
            FireBullet(Quaternion.Euler(0, -30, 0) * shootingPoint.forward);
        }
        else
        {
            FireBullet(shootingPoint.forward);
        }
    }

    private void FireBullet(Vector3 direction)
    {
        GameObject newBullet = Instantiate(bullet, shootingPoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = direction.normalized * 10f;
        }

        Debug.Log("Bullet Fired with direction: " + direction);
    }

    public void EnableSpreadShot()
    {
        Debug.Log("Spread Shot Picked Up!");
        spreadShotEnabled = true;
    }

    public void StartFireRateBoost(float duration, float multiplier)
    {
        if (!isFireRateBoosted)
        {
            StartCoroutine(IncreaseFireRate(duration, multiplier));
        }
    }

    private IEnumerator IncreaseFireRate(float duration, float multiplier)
    {
        isFireRateBoosted = true;
        fireRate /= multiplier;
        yield return new WaitForSeconds(duration);
        fireRate = defaultFireRate;
        isFireRateBoosted = false;
    }


}


