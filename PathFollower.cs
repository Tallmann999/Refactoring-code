using UnityEngine;
<<<<<<< HEAD
using static UnityEngine.GraphicsBuffer;
=======
>>>>>>> main

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Transform _pathTarget;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Transform[] _points;

    private int _currentPointIndex = 0;

    private void Update()
    {
<<<<<<< HEAD
        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _movingSpeed * Time.deltaTime);

        if (transform.position == target.position)
            MoveToPoints();
=======
        MoveToPoints();
>>>>>>> main
    }

    [ContextMenu("Refresh Child Array")]
    private void InitPoints()
    {
        _points = new Transform[_pathTarget.childCount];

        for (int i = 0; i < _pathTarget.childCount; i++)
        {
            _points[i] = _pathTarget.GetChild(i);
        }
    }

<<<<<<< HEAD
    private Vector3 MoveToPoints()
    {
        if (_currentPointIndex == _points.Length)
            _currentPointIndex = ++_currentPointIndex % _points.Length;

        Vector3 currentPosition = _points[_currentPointIndex].transform.position;
        transform.forward = currentPosition - transform.position;
        return currentPosition;
=======
    private void MoveToPoints()
    {
        Transform target = _points[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _movingSpeed * Time.deltaTime);

        if (transform.position == target.position)
            _currentPointIndex = ++_currentPointIndex % _points.Length;
>>>>>>> main
    }
}
