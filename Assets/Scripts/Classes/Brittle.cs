using UnityEngine;

public class Brittle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
        => Destroy(this.gameObject);
}
