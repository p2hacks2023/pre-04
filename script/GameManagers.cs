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
            ; // �}�E�X�������ꂽ��t���O�� false �ɐݒ�


        }
        if (Input.GetMouseButton(0) )
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            coolingGelSheetPrefab.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            
        }
        if (Input.GetMouseButtonUp(0))//�����}�E�X�������ꂽ��i0�͍�1�͉E�j
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;


        }
    }
}
