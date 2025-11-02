using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Transform _target;


    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 shootingDirection = (_target.position - transform.position).normalized;
            GameObject NewBullet = Instantiate(_bulletPrefab, transform.position + shootingDirection, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = shootingDirection;
            NewBullet.GetComponent<Rigidbody>().velocity = shootingDirection * _bulletSpeed;

            yield return new WaitForSeconds(_shootingDelay);
        }
    }
}
