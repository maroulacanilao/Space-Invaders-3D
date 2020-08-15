using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public string CollisionTag;
    Stats mStats;

    void Start()
    {
        mStats = this.gameObject.GetComponent<Stats>();
    }

    void Update()
    {
        
    }

}
