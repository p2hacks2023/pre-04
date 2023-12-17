using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CGSManager2 : MonoBehaviour
{
    private Rigidbody rb;
    private bool isStuck = false;
    public Transform objectA;
    public Transform objectB;
    public ScoreManager scoreManager;
    public scoreStanderdMover standerdMover;
    // シーン内で scoreStandard オブジェクトを直接アタッチするか、Inspector から関連するオブジェクトを設定してください
    public Transform scoreStandard;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        standerdMover = FindObjectOfType<scoreStanderdMover>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("wall"))
        {
            isStuck = true;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            float distance = Vector3.Distance(objectA.position, objectB.position);
            int score = CalculateScore(distance);
            // PlayerPrefs にスコアを保存
            SaveScore(score);
            scoreManager.ShowScoreAnimation(score, "stage3");

            if (standerdMover != null)
            {
                standerdMover.moveSpeed = 0f;
            }
            HideNomalFace();
        }
    }

    private int CalculateScore(float distance)
    {
        if (distance <= 1)
        {
            return 100;
        }
        else if (distance > 1 && distance <= 2)
        {
            return 60;
        }
        else if (distance > 2 && distance <= 3)
        {
            return 30;
        }
        else
        {
            return 0;
        }
    }
    private void SaveScore(int score)
    {
        // PlayerPrefs にスコアを保存
        int currentScore = PlayerPrefs.GetInt("Stage3Score", 0);
        int newScore = currentScore + score;
        PlayerPrefs.SetInt("Stage3Score", newScore);
    }
    private void HideNomalFace()
    {
        if (scoreStandard != null)
        {
            // scoreStandard オブジェクトの子供である nomalFace を取得
            Transform nomalFace = scoreStandard.Find("nomalFace");

            if (nomalFace != null)
            {
                // nomalFace を非表示にする
                nomalFace.gameObject.SetActive(false);
            }
        }
    }
}
