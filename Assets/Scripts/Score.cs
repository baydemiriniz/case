using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text coins;
    public int score;
    public int totalWonScore = 5;

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        int totalScore;
        score++;
        totalScore = score;
        coins.text = (totalScore * 10).ToString() + " Coins";
        text.text = totalScore + " / " + totalWonScore;
        if (totalScore >= totalWonScore)
        {
            GameManager.Instance.playerController.passFlag = true;
        }
    }
}