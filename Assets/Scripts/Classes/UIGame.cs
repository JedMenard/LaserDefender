using TMPro;
using UnityEngine;

public class UIGame : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        this.scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    private void Update()
    {
        this.scoreText.text = this.scoreKeeper.Score.ToString("D5");
    }
}
