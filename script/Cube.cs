using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector3 objPos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        objPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        objPos.y = this.transform.position.y;
        this.transform.position = objPos;
        Debug.Log(mousePos);
    }
}
