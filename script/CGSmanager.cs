using TMPro;
using UnityEngine;

public class CGSManager : MonoBehaviour
{
    private Rigidbody rb;
    private bool isStuck = false;
    public Transform objectA;
    public Transform objectB;
    public AudioClip soundEffect; // ���₦�s�^�̌��ʉ�
    private AudioSource audioSource;
    public ScoreManager scoreManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // OnCollisionEnter���Փˎ��ɌĂяo�����
   void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("wall"))
        {

            isStuck = true;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            // �I�u�W�F�N�gA�ƃI�u�W�F�N�gB�̋������v�Z
            float distance = Vector3.Distance(objectA.position, objectB.position);
            // �X�R�A���v�Z
            int score = CalculateScore(distance);
            // PlayerPrefs �ɃX�R�A��ۑ�
            SaveScore(score);
            // ScoreManager���Ăяo���ăX�R�A��\��
            scoreManager.ShowScoreAnimation(score, "stage2");
            // ���₦�s�^�̌��ʉ����Đ�
            PlaySoundEffect();
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
        int currentScore = PlayerPrefs.GetInt("Stage2Score", 0); // "Stage2Score" �̓L�[�Ƃ��Ďg���܂�
        int newScore = currentScore + score;
        PlayerPrefs.SetInt("Stage2Score", newScore);
    }
    private void PlaySoundEffect()
    {
        if (soundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
