using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Stats mStats;

    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        mStats = GetComponent<Stats>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal") * mStats.getMovementSpeed();
        movement *= Time.deltaTime;

        transform.Translate(movement, 0, 0);


        //Debug//
        if (Input.GetKeyDown(KeyCode.End)) Dies();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            mStats.SetCurrentHp(
                mStats.getCurrentHp()
                - collision.gameObject.GetComponent<BulletMovement>().damage);
            if (mStats.getCurrentHp() <= 0)
            {
                Dies();
            }
        }
    }


    void Dies()
    {
        Time.timeScale = 0;
        Canvas.GetComponent<LoseScreen>().enabled = true;
    }
}
