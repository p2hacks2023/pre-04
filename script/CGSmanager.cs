using TMPro;
using UnityEngine;

public class CGSManager : MonoBehaviour
{
    private Rigidbody rb;
    private bool isStuck = false;
    public Transform objectA;
    public Transform objectB;
    public AudioClip soundEffect; // 着冷えピタの効果音
    private AudioSource audioSource;
    public ScoreManager scoreManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // OnCollisionEnterが衝突時に呼び出される
   void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("wall"))
        {

            isStuck = true;
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            // オブジェクトAとオブジェクトBの距離を計算
            float distance = Vector3.Distance(objectA.position, objectB.position);
            // スコアを計算
            int score = CalculateScore(distance);
            // PlayerPrefs にスコアを保存
            SaveScore(score);
            // ScoreManagerを呼び出してスコアを表示
            scoreManager.ShowScoreAnimation(score, "stage2");
            // 着冷えピタの効果音を再生
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
        // PlayerPrefs にスコアを保存
        int currentScore = PlayerPrefs.GetInt("Stage2Score", 0); // "Stage2Score" はキーとして使います
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
