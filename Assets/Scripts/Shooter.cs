using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _target;

    private Coroutine _shootCoroutine;

    private void OnEnable()
    {
        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_shootCoroutine);
    }

    private IEnumerator ShootCoroutine()
    {
        bool isShooting = true;
        var delay = new WaitForSeconds(_shootingDelay);

        while (isShooting)
        {
            Vector3 shootingDirection = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + shootingDirection, Quaternion.identity);
            bullet.Init(shootingDirection, _bulletSpeed);          

            yield return delay;
        }
    }
}
