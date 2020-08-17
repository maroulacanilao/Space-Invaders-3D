using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Stats mStats;

    public GameObject Canvas;

    float MinX = -100;
    float MaxX = 100;
    // Start is called before the first frame update
    void Start()
    {
        mStats = GetComponent<Stats>();
        Time.timeScale = 1;
        MinX = -95.0f;
        MaxX = 95.0f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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

    void PlayerMovement()
    {
        var horizontal = Input.GetAxis("Horizontal") * mStats.getMovementSpeed() * Time.deltaTime;

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + horizontal, MinX, MaxX);
        transform.position = pos;
    }
}
