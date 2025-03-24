using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private bool spreadShotEnabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (spreadShotEnabled)
        {
            FireBullet(Vector2.up * 0.2f);
            FireBullet(Vector2.zero);
            FireBullet(Vector2.down * 0.2f);
        }
        else
        {
            FireBullet(Vector2.zero);
        }
    }

    private void FireBullet(Vector2 directionOffset)
    {
        GameObject newBullet = Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector2 direction = (Vector2.right + directionOffset).normalized;
            rb.velocity = direction * 5f;
        }
    }

    public void EnableSpreadShot()
    {
        spreadShotEnabled = true;
    }

    public void StartFireRateBoost()
    {
        StartCoroutine(IncreaseFireRate(duration, multiplier));
    }

    private IEnumerator IncreaseFireRate(float duration, float multiplier)
    {
        fireRate /= multiplier;
        yield return new WaitForSeconds(duration);
        fireRate *= multiplier;
    }
}
