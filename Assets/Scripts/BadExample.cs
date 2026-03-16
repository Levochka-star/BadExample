using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private float _speed;

    private Transform[] _arrayPlaces;
    private int _numberInArrayPlaces;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var pointNumberInArray = _arrayPlaces[_numberInArrayPlaces];
        transform.position = Vector3.MoveTowards(transform.position, pointNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointNumberInArray.position)
        {
            PositionAcquirer();
        }
    }

    private Vector3 PositionAcquirer()
    {
        _numberInArrayPlaces++;

        if (_numberInArrayPlaces == _arrayPlaces.Length)
            _numberInArrayPlaces = 0;

        var thisPointVector = _arrayPlaces[_numberInArrayPlaces].transform.position;
        transform.forward = thisPointVector - transform.position;

        return thisPointVector;
    }
}