using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public GameObject coolingGelSheetPrefab;
    private Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            ; // マウスが押されたらフラグを false に設定


        }
        if (Input.GetMouseButton(0) )
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            coolingGelSheetPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            
        }
        if (Input.GetMouseButtonUp(0))//もしマウスが押されたら（0は左1は右）
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;


        }
    }
}
