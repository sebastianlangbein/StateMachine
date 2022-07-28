using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float speed = 5f;

    void Update()
    {
        //to find the direction from a -> b
        //Dir = b - a
        Vector2 directionToPlayer = _player.transform.position - transform.position;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
