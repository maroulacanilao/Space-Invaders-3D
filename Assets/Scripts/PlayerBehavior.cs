using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Stats mStats;

    public GameObject LoseScreen;
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
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
        gameObject.GetComponent<PlayerBehavior>().enabled = false;
        gameObject.GetComponent<BulletShooter>().enabled = false;
        Time.timeScale = 0;
        LoseScreen.SetActive(true);
    }
}
