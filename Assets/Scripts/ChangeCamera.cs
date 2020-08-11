using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
    public Camera ThirdPOV;
    public Camera FirstPOV;

    public Image Crosshair;
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
            changeView();
        }
    }
    void changeView()
    {
        if(Switch == true)
        {
            ThirdPOV.gameObject.SetActive(true);
            FirstPOV.gameObject.SetActive(false);
            //Crosshair.gameObject.transform.position = new Vector3(0, 120,0);
        }
        if (Switch == false)
        {
            ThirdPOV.gameObject.SetActive(false);
            FirstPOV.gameObject.SetActive(true);
           // Crosshair.gameObject.transform.position = new Vector3(0, 0,0);
        }

    }
}
