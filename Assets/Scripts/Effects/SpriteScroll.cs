using UnityEngine;

public class SpriteScroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 scrollSpeed;

    private Material material;

    private void Awake()
        => this.material = this.GetComponent<SpriteRenderer>().material;

    private void Update()
        => this.material.mainTextureOffset += this.scrollSpeed * Time.deltaTime;
}
