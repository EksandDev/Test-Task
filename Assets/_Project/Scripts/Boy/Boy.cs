using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Seeker), typeof(CharacterController))]
public class Boy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 3;

    private ScoreChanger _scoreChanger;
    private Seeker _seeker;
    private Path _path;
    private CharacterController _controller;
    private Transform _target;
    private bool _reachedEndOfPath;
    private int _currentWaypoint = 0;
    private int _nextWaypointDistance = 3;

    private const string IS_WALKING = "IsWalking";
    private const string IS_DANCING = "IsDancing";

    public Transform Target => _target;

    public void Initialization(ScoreChanger scoreChanger, Transform target)
    {
        _scoreChanger = scoreChanger;
        _target = target;
        _seeker = GetComponent<Seeker>();
        _controller = GetComponent<CharacterController>();

        _seeker.StartPath(transform.position, _target.position, OnPathComplete);
    }

    public void Dance()
    {
        _animator.SetBool(IS_WALKING, false);
        _animator.SetBool(IS_DANCING, true);
        float timeToDestroy = _animator.GetCurrentAnimatorClipInfo(0).Length * 3;
        Destroy(gameObject, timeToDestroy);
    }

    private void OnPathComplete(Path path)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + path.error);

        if (!path.error)
        {
            _path = path;
            _currentWaypoint = 0;
            _animator.SetBool(IS_WALKING, true);
        }
    }

    private void Update()
    {
        if (_path == null)
            return;

        _reachedEndOfPath = false;
        float distanceToWaypoint;

        while (true)
        {
            distanceToWaypoint = Vector3.Distance(transform.position, _path.vectorPath[_currentWaypoint]);

            if (distanceToWaypoint < _nextWaypointDistance)
            {
                if (_currentWaypoint + 1 < _path.vectorPath.Count)
                    _currentWaypoint++;

                else
                {
                    _reachedEndOfPath = true;
                    break;
                }
            }

            else
                break;
        }

        var speedFactor = _reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / _nextWaypointDistance) : 1f;
        Vector3 direction = (_path.vectorPath[_currentWaypoint] - transform.position).normalized;
        Vector3 velocity = direction * _speed * speedFactor;
        _controller.SimpleMove(velocity);
    }

    private void OnDestroy() => _scoreChanger.ChangeScore(1);
}