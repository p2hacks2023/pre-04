using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        // 合算されたスコアを取得
        int totalScore = CalculateTotalScore();

        // スコアを表示する
        if (scoreText != null)
        {
            scoreText.text = "Total Score: " + totalScore.ToString();
        }
    }

    int CalculateTotalScore()
    {
        // 各ゲームプレイで得たスコアを合算
        int score1 = PlayerPrefs.GetInt("Score1", 0);
        int score2 = PlayerPrefs.GetInt("Score2", 0);
        int score3 = PlayerPrefs.GetInt("Score3", 0);

        int totalScore = score1 + score2 + score3;

        return totalScore;
    }

    public void GoToMainMenu()
    {
        // メインメニューシーンに戻る
        SceneManager.LoadScene("MainMenu");
    }
}
