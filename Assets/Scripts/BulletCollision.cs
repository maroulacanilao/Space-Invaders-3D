using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public string CollisionTag;
    Stats mStats;
    // Start is called before the first frame update
    void Start()
    {
        mStats = this.gameObject.GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CollisionTag))
        {
            mStats.SetCurrentHp(
                mStats.getCurrentHp()
                - collision.gameObject.GetComponent<BulletMovement>().damage);
            Destroy(collision.gameObject);
        }
        if (this.gameObject.CompareTag("Destruct.Wall"))
        {
            if (collision.gameObject.CompareTag("EnemyBullet"))
            {
                mStats.SetCurrentHp(
                        mStats.getCurrentHp()
                                 - collision.gameObject.GetComponent<BulletMovement>().damage);
                Destroy(collision.gameObject);
            }
        }
    }
}
