using UnityEngine;

public class ScoreGiver : MonoBehaviour
{
    [SerializeField]
    private int score = 1;

    public void GiveScore()
    {
        FindObjectOfType<ScoreKeeper>().AddScore(this.score);
    }
}
