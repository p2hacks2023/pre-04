using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShape : MonoBehaviour
{
    public Material imageMaterial; // �}�e���A���Ɏg���摜
    // Start is called before the first frame update
    void Start()
    {
        // �L���[�u����X�N�G�A�ɃX�P�[���ύX
        ChangeToSquare();

        // �摜���I�u�W�F�N�g�ɓ\��t����
        ApplyImage();
    }

    void ChangeToSquare()
    {
        // �I�u�W�F�N�g�̃X�P�[����ύX���ăL���[�u����X�N�G�A�ɂ���
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void ApplyImage()
    {
        // �}�e���A�����w�肳��Ă���ꍇ�ɉ摜���I�u�W�F�N�g�ɓK�p
        if (imageMaterial != null)
        {
            // �I�u�W�F�N�g��Renderer�R���|�[�l���g���擾
            Renderer objectRenderer = GetComponent<Renderer>();

            // �}�e���A����ݒ�
            objectRenderer.material = imageMaterial;
        }
    }
}
