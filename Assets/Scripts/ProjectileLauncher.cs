using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private float _speedFlyBullet;
    [SerializeField] private float _timeShooting;
    [SerializeField] private GameObject _prefabBullets;

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
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeShooting);

        while (enabled)
        {
            yield return waitForSeconds;

            Vector3 vector3Direction = (_objectTarget.position - transform.position).normalized;
            
            GameObject newBullet = Instantiate(_prefabBullets, transform.position + vector3Direction, Quaternion.identity);

            if (newBullet.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.transform.up = vector3Direction;
                rigidbody.velocity = vector3Direction * _speedFlyBullet;
            }
        }
    }
}