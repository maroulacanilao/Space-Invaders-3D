using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera ThirdPOV;
    public Camera FirstPOV;

    bool Switch = true;
    // Start is called before the first frame update
    void Start()
    {
        ThirdPOV.gameObject.SetActive(true);
        FirstPOV.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Switch = !Switch;
        }
        changeView();
    }
    void changeView()
    {
        if(Switch == true)
        {
            ThirdPOV.gameObject.SetActive(true);
            FirstPOV.gameObject.SetActive(false);
        }
        if (Switch == false)
        {
            ThirdPOV.gameObject.SetActive(false);
            FirstPOV.gameObject.SetActive(true);
        }

    }
}
