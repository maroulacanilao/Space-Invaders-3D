using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            mStats.SetCurrentHp(
                mStats.getCurrentHp()
                -collision.gameObject.GetComponent<BulletMovement>().damage);
            Destroy(collision.gameObject);
        }
    }
}
