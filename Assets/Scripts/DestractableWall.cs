using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestractableWall : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= collision.gameObject.GetComponent<BulletMovement>().damage;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
