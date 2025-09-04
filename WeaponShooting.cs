using System.Collections;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeWaitShooting;

    private Transform _target;
    private Coroutine _currentCoroutine;

    public Transform Target => _target;

    private void Start()
    {
        if (_currentCoroutine == null)
        {
            StopCoroutine(Shooting());
        }

        _currentCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.transform.up = direction;
            bulletRb.linearVelocity = direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}