using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plataformas2 : MonoBehaviour
{

    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _chechDistance = 0.05f;
    private Transform _targetWaypoint;
    private int _currentWaypointIndex = 0;



    // Start is called before the first frame update
    private void Start()
    {
        _targetWaypoint = _waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _targetWaypoint.position,
            _speed * Time.deltaTime
            );
        if (Vector2.Distance(transform.position, _targetWaypoint.position) < _chechDistance)
        {
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++;
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        return _waypoints[_currentWaypointIndex];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }

    }
}
