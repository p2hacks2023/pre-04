using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CGSManager3 : MonoBehaviour
{
    private Rigidbody rb;
    private bool isStuck = false;
    public Transform objectA;
    public Transform objectB;
    public ScoreManager scoreManager;
    public standerdWaveMover standardWaveMover;
    public Transform scoreStandard;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        standardWaveMover = FindObjectOfType<standerdWaveMover>();
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
            scoreManager.ShowScoreAnimation(score, "result");

            if (standardWaveMover != null)
            {
                standardWaveMover.StopMoving();
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
        int currentScore = PlayerPrefs.GetInt("ResultScore", 0);
        int newScore = currentScore + score;
        PlayerPrefs.SetInt("ResultScore", newScore);
    }

    private void HideNomalFace()
    {
        if (scoreStandard != null)
        {
            Transform nomalFace = scoreStandard.Find("nomalFace");

            if (nomalFace != null)
            {
                nomalFace.gameObject.SetActive(false);
            }
        }
    }
}
