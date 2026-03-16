using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private float _speedFlyBullet;
    [SerializeField] private float _timeShooting;
    [SerializeField] private GameObject _prefab;

    private Coroutine _coroutine;
    private Transform _objectTarget;

    private void Start()
    {
        _coroutine = StartCoroutine(WaitShootingWorker());
    }

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator WaitShootingWorker()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_timeShooting);

            var vector3Direction = (_objectTarget.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vector3Direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vector3Direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3Direction * _speedFlyBullet;
        }
    }
}