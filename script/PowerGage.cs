using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGage : MonoBehaviour
{
    private float power;
    public Rigidbody rb;
    public Slider slider;
    public AudioSource audioSource; // AudioSource�ϐ��̒ǉ�
    public AudioClip throwSound; // ���ʉ��̂��߂�AudioClip�ϐ��̒ǉ�

    void Start()
    {
        power = 0;
        slider.value = 0;
        // AudioSource�̏����ݒ�
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = throwSound;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if (power < 10)
            {
                power += 0.05f;
            }
            else
            {
                power = 0; // 10�ȏ�ɂȂ�����0�ɖ߂�
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = true;

            // �{�[�������Z�b�g

            rb.AddForce(0, 0, power * 2, ForceMode.Impulse);

            // ������̊p�x��������
            Vector3 upwardForce = new Vector3(0, (float)0.5, 0);
            rb.velocity = 2 * power * upwardForce;
            power = 0;

            // ���ʉ����Đ�
            audioSource.Play();
        }
        slider.value = power * 0.1f;
    }
}