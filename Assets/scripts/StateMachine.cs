using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiAgent))]
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

    private AiAgent _aiAgent;

    private void Start()
    {
        //grabs the first AiAgent (whatever is in <>) and puts it in the variable
        _aiAgent = GetComponent<AiAgent>();

        NextState();
    }

    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            default:
                Debug.LogWarning("_state doesn't exist within nextState function");
                break;
        }
    }

    //Ienumerator required for a coroutine
    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.Search();
        while (_state == State.Patrol)
        {
            _aiAgent.Patrol();
            if (_aiAgent.IsPlayerInRange())
            {
                _state = State.Chase;
            }
            //some yield is required for a coroutine
            yield return null; //wait a single frame
            //yield return new WaitForSeconds(5); //wait for 5 seconds
        }
        
        Debug.Log("Patrol: Exit");

        NextState();
    }

    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == State.Chase)
        {
            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            //some yield is required for a coroutine
            yield return null; //wait a single frame
        }

        Debug.Log("Chase: Exit");
        NextState();
    }
}
