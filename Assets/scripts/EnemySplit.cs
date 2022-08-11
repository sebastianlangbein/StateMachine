using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplit : MonoBehaviour
{
    //Unity cant view this public field
    public Bullet splitByBullet = null;
    [SerializeField] float splitReduction = 0.1f;
    [SerializeField] float smallestSize = 0.1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet == splitByBullet) return;

            transform.localScale *= splitReduction;
            if(transform.localScale.x < smallestSize)
            {
                Destroy(gameObject);
                return;
            }
            splitByBullet = bullet;
            GameObject newGO = Instantiate(gameObject, transform.position, transform.rotation);

            //newGO.GetComponent<EnemySplit>().Explode(bullet.transform.position);
            //Explode(bullet.transform.position);
        }
    }
    //public void Explode(Vector3 point)
    //{
    //    Vector2 force = transform.position - point;
    //    force = force.normalized * 300f;

    //    gameObject.GetComponent<Rigidbody2D>().AddForce(force);
    //}
}
