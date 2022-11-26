using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public bool rotate;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }

        if (rotate)
        {
            transform.Rotate(new Vector3(25, 25, 0) * Time.deltaTime);
        }
    }

    public void StartRotate()
    {
        rotate = true;
    }

    public void StopRotate()
    {
        rotate = false;
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
