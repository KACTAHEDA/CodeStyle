using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _target;

    private void OnEnable()
    {
        StartCoroutine(ShootCoroutine());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ShootCoroutine()
    {
        bool isShooting = true;

        while (isShooting)
        {
            Vector3 shootingDirection = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + shootingDirection, Quaternion.identity);
            bullet.Init(shootingDirection, _bulletSpeed);          

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}
