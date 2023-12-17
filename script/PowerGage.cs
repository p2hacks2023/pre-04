using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGage : MonoBehaviour
{
    private float power;
    public Rigidbody rb;
    public Slider slider;
    public AudioSource audioSource; // AudioSource変数の追加
    public AudioClip throwSound; // 効果音のためのAudioClip変数の追加

    void Start()
    {
        power = 0;
        slider.value = 0;
        // AudioSourceの初期設定
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
                power = 0; // 10以上になったら0に戻す
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = true;

            // ボールをリセット

            rb.AddForce(0, 0, power * 2, ForceMode.Impulse);

            // 上向きの角度を加える
            Vector3 upwardForce = new Vector3(0, (float)0.5, 0);
            rb.velocity = 2 * power * upwardForce;
            power = 0;

            // 効果音を再生
            audioSource.Play();
        }
        slider.value = power * 0.1f;
    }
}