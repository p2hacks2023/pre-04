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
    // �V�[������ scoreStandard �I�u�W�F�N�g�𒼐ڃA�^�b�`���邩�AInspector ����֘A����I�u�W�F�N�g��ݒ肵�Ă�������
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
            // PlayerPrefs �ɃX�R�A��ۑ�
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
        // PlayerPrefs �ɃX�R�A��ۑ�
        int currentScore = PlayerPrefs.GetInt("Stage3Score", 0);
        int newScore = currentScore + score;
        PlayerPrefs.SetInt("Stage3Score", newScore);
    }
    private void HideNomalFace()
    {
        if (scoreStandard != null)
        {
            // scoreStandard �I�u�W�F�N�g�̎q���ł��� nomalFace ���擾
            Transform nomalFace = scoreStandard.Find("nomalFace");

            if (nomalFace != null)
            {
                // nomalFace ���\���ɂ���
                nomalFace.gameObject.SetActive(false);
            }
        }
    }
}
