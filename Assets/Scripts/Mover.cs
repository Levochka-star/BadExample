using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _containerPointPath;
    [SerializeField] private float _travelSpeed;

    private Transform[] _pointsPath;
    private int _indexPlace;

    private void Start()
    {
        _pointsPath = new Transform[_containerPointPath.childCount];

        for (int i = 0; i < _pointsPath.Length; i++)
            _pointsPath[i] = _containerPointPath.GetChild(i);
    }

    private void Update()
    {
        var pointPath = _pointsPath[_indexPlace];

        transform.position = Vector3.MoveTowards(transform.position, pointPath.position, _travelSpeed * Time.deltaTime);

        if (transform.position == pointPath.position)
        {
            Move();
        }
    }

    private Vector3 Move()
    {
        _indexPlace = ++_indexPlace % _pointsPath.Length;

        var vectorPath = _pointsPath[_indexPlace].transform.position;
        transform.forward = vectorPath - transform.position;

        return vectorPath;
    }
}