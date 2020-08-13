using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Stats mStats;
    // Start is called before the first frame update
    void Start()
    {
        mStats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal") * mStats.getMovementSpeed();
        movement *= Time.deltaTime;

        transform.Translate(movement, 0, 0);

        //Debug//
        if(Input.GetKey(KeyCode.K))
        {
            GameObject[] Fleet = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i=0;i<Fleet.Length;i++)
            {
                Destroy(Fleet[i].gameObject);
            }
        }
    }

}
