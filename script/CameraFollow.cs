using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �J�������Ǐ]����Ώہi�{�[���j
    public float smoothSpeed = 0.125f; // �J�����̒ǔ��̊��炩��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            // �J�����̈ʒu���{�[����X��Y���W�ɒǏ]������
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            // �^�[�Q�b�g�����݂��Ȃ��ꍇ�A�J�������j������
            Destroy(gameObject);
        }
    }
}
