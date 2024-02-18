using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Rotate : MonoBehaviour
{
    public Vector3 speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationToAdd;
        
        if (Input.GetKey(KeyCode.A))
        {
             rotationToAdd = speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
             rotationToAdd = -speed;
        }
        else
        {
            rotationToAdd = new Vector3(0f,0f,0f);
        }

        if (Input.GetKey(KeyCode.R))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        transform.Rotate(rotationToAdd);
    }
}
