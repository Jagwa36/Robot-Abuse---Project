using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class scr_TestCase : MonoBehaviour
{
    public scr_Clickables torso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test Case #1: Torso should never be detacched unless it is also highlighted
        if (!torso.highlighted && !torso.parented && !Input.GetKey(KeyCode.Mouse0))
                Debug.Log("FAIL: Torso is both unparented and unhighlighted");

        //Test Case #2: Parent of Torso should always be white
        if (torso.parent != null && torso.parent.GetComponent<Renderer>().material.color != Color.white)
            Debug.Log("FAIL: Torso's parent is not white");
    }
}
