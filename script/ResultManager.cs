using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // ���Z���ꂽ�X�R�A���擾
        int totalScore = CalculateTotalScore();

        // �X�R�A��\������
        if (scoreText != null)
        {
            scoreText.text = "Total Score: " + totalScore.ToString();
        }
    }

    int CalculateTotalScore()
    {
        // �e�Q�[���v���C�œ����X�R�A�����Z
        int score1 = PlayerPrefs.GetInt("Score1", 0);
        int score2 = PlayerPrefs.GetInt("Score2", 0);
        int score3 = PlayerPrefs.GetInt("Score3", 0);

        int totalScore = score1 + score2 + score3;

        return totalScore;
    }

    public void GoToMainMenu()
    {
        // ���C�����j���[�V�[���ɖ߂�
        SceneManager.LoadScene("MainMenu");
    }
}
