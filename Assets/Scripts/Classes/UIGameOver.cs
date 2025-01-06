using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private ScoreKeeper scoreKeeper;

    private void Awake() => this.scoreKeeper = FindObjectOfType<ScoreKeeper>();

    private void Start() => this.scoreText.text = "Final score:\n" + this.scoreKeeper.Score;
}
