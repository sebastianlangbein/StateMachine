using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = transform.up;
        Vector2 position = transform.position;
        direction = direction.normalized * _speed * Time.deltaTime;
        transform.position = position + direction;

        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;
        Rect bulletRect = new Rect(-(camWidth/2),-(camHeight/2),camWidth,camHeight);
        if (!bulletRect.Contains(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
