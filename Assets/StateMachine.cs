using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Aware,
        Chase
    }

    //AI's current state
    [SerializeField] private State _state;

    private void Start()
    {
        NextState();
    }

    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            //case State.Chase:
                //StartCoroutine(ChaseState());
            default:
                Debug.LogWarning("_state doesn't exist within nextState function");
                break;
        }
        if (_state == State.Patrol)
        {
            StartCoroutine(PatrolState());
        }
    }

    //Ienumerator required for a coroutine
    private IEnumerator PatrolState()
    {
        //some yield is required for a coroutine
        yield return null; //wait a single frame
    }
}
