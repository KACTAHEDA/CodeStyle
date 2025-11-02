
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private Transform _movePointsContainer;

    private Transform[] _movePoints;
    private int _curentMovePointIndex;

    private void Start()
    {
        SetNewPath();
    }

    private void Update()
    {
        if (_movePoints == null || _movePoints.Length == 0)
        {
            return;
        }

        Move();       
    }

    private void SetNewPath()
    {
        _movePoints = new Transform[_movePointsContainer.childCount];

        for (int i = 0; i < _movePointsContainer.childCount; i++)
            _movePoints[i] = _movePointsContainer.GetChild(i).GetComponent<Transform>();
    }

    private Vector3 SelectNextTarget()
    {
        _curentMovePointIndex++;

        if (_curentMovePointIndex == _movePoints.Length)
            _curentMovePointIndex = 0;

        var thisPointVector = _movePoints[_curentMovePointIndex].transform.position;
        transform.forward = thisPointVector - transform.position;
        return thisPointVector;
    }

    private void Move()
    {
        var _targetPoint = _movePoints[_curentMovePointIndex];
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == _targetPoint.position) 
            SelectNextTarget();
    }
}
