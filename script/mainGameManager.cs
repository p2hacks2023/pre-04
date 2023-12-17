using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject spawnedBullet; // �������ꂽbullet
    private Vector3 mousePos;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            // ���ɐ������ꂽbullet������΍폜
            if (spawnedBullet != null)
            {
                Destroy(spawnedBullet);
            }
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            //�{�[���𐶐�
            spawnedBullet = Instantiate(bulletPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
            // �q�I�u�W�F�N�g�ɉ摜��K�p
            ApplyImageToChild(spawnedBullet);
        }
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            spawnedBullet.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        }
        if (Input.GetMouseButtonUp(0))//�����}�E�X�������ꂽ��i0�͍�1�͉E�j
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5f;

        }
    }
        void ApplyImageToChild(GameObject parentObject)
        {
        // �e�I�u�W�F�N�g��null�łȂ����Ƃ��m�F
        if (parentObject != null)
            {
                // �����_���[�R���|�[�l���g���A�^�b�`����Ă��邩�m�F
                Renderer parentRenderer = parentObject.GetComponent<Renderer>();
                if (parentRenderer != null)
                {
                    // �e�̃����_���[�R���|�[�l���g�ɉ摜��K�p
                    parentRenderer.material = GetImageMaterial(); // GetImageMaterial()�͉摜�̃}�e���A����Ԃ����\�b�h�Ƃ��Ď������Ă�������
                }
            }
        }
    Material GetImageMaterial()
        {
            // �����ɉ摜�̃}�e���A�����擾���鏈��������
            // �Ⴆ�΁AResources.Load�Ȃǂ��g�p���ă}�e���A����ǂݍ���
            // ���̗�ł�Resources�t�H���_�Ƀ}�e���A����z�u���Ă���Ɖ���
            Material imageMaterial = Resources.Load<Material>("image/hiepita");


        return imageMaterial;
    }
}
