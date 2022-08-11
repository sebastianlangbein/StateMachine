using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.up;
        Vector2 position = transform.position;
        direction = direction.normalized * _speed * Time.deltaTime;
        transform.position = position + direction;
    }
}
