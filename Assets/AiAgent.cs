using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 5f;

    [SerializeField] private Transform[] _waypoints; //declaring the array, usually you would need to intitialise, but not necessary in unity with serializefield
    [SerializeField] private int _waypointIndex = 0;

    private void Start()
    {
        Debug.Log(0 % 6);
    }
    private void Update()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;

        MoveToPoint(waypointPosition);

        if (Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            //_waypointIndex = (_waypointIndex++) % _waypoints.Length;
            _waypointIndex++;
            if(_waypointIndex >= _waypoints.Length)
            {
                _waypointIndex = 0;
            }
        }
    }

    //               parameter
    void MoveToPoint(Vector2 point)
    {
        //to find the direction from a -> b
        //Dir = b - a
        Vector2 directionToPoint = point - (Vector2)transform.position;
        if (directionToPoint.magnitude > 0.1f)
        {
            directionToPoint.Normalize();
            directionToPoint *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPoint;
        }
    }
}
