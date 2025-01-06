using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int Score { get; private set; } = 0;

    private static ScoreKeeper instance;

    private void Awake()
    {
        if (instance != null)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int AddScore(int increase) => this.Score += increase;

    public void ResetScore() => this.Score = 0;
}
