using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    Camera _camera;
    [SerializeField]
    private GameObject _bulletPrefab;
    private void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 clickLocation = _camera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 clickDirection = clickLocation - transform.position;

            //spawn a projectile
            GameObject.Instantiate(_bulletPrefab, transform.position, Quaternion.FromToRotation(Vector2.up, clickDirection));
            //give bullet move direction

        }
    }
}
