using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool trigger = false;
    public float switchSide = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switchSide = Random.Range(0f, 1.0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
       

    }
}
