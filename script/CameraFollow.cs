using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // カメラが追従する対象（ボール）
    public float smoothSpeed = 0.125f; // カメラの追尾の滑らかさ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // カメラの位置をボールのXとY座標に追従させる
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            // ターゲットが存在しない場合、カメラも破棄する
            Destroy(gameObject);
        }
    }
}
