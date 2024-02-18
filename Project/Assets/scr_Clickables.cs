using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//scr_Clickable by AJG
//This code is to be put on a hierarchy of parented models in a 3d space.
//Clicking on them with the mouse will allow them to be dragged around.
//To implement simply slap it onto each object and the furthest up should be marked as torso.

//Blue objects are unattached. Red objects are highlighted. And white objects are attached.
//

public class scr_Clickables : MonoBehaviour
{
    private Renderer _renderer;
    public bool parented = true;
    public bool highlighted;
    public GameObject parent;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPosition;
    public Text HUD;
    public bool torso;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();

        initialPosition = transform.localPosition;

        parent = this.transform.parent.gameObject;
        parented = true;
    }

    private void Update()
    {
        if (parented && !highlighted)
            _renderer.material.color = parent.GetComponent<Renderer>().material.color;

        if (highlighted) 
            _renderer.material.color = Color.red;
        else if (!parented)
            _renderer.material.color = Color.blue;

    }

    // Update is called once per frame
    void OnMouseEnter()
    {
        UpdateText();

        highlighted = true;
    }

    void OnMouseDown()
    {
        transform.SetParent(null);

       parented = !parented;

       screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
       offset = gameObject.transform.localPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

       UpdateText();
    }

    void OnMouseUp()
    {
        if (torso)
            parented = true;

        if (parented)
            transform.SetParent(parent.transform);
    }

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.localPosition = cursorPosition;
    }

    private void OnMouseExit()
    {
        highlighted = false;
        _renderer.material.color = Color.white;
    }

    public void UpdateText()
    {
        if (torso)
            HUD.text = ">Torso ";
        else if (parented)
            HUD.text = ">Attached ";
        else
            HUD.text = ">Dettached ";
    }
}
