using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform _pathTarget;

    private Transform[] _targetPoints;
    private float _speed;
    private int _currentIndex;

    private void Start()
    {
        InitializeTarget();
    }

    [ContextMenu("Refresh Child Array")]
    private void InitializeTarget()
    {
        _targetPoints = new Transform[_pathTarget.childCount];

        for (int i = 0; i < _pathTarget.childCount; i++)
        {
            _targetPoints[i] = _pathTarget.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform currentPoint = _targetPoints[_currentIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position)
        {
            NextPlaceTakerLogic();
        }
    }

    private Vector3 NextPlaceTakerLogic()
    {
        _currentIndex++;

        if (_currentIndex == _targetPoints.Length)
            _currentIndex = 0;

        Vector3 currentPosition = _targetPoints[_currentIndex].transform.position;
        transform.forward = currentPosition - transform.position;
        return currentPosition;
    }
}
