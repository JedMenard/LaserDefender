using UnityEngine;

public class DespawnOutOfBounds : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.InitBounds();
    }

    private void Update()
    {
        this.CheckBounds();
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;

        // Start with the base values.
        this.minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        this.maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        // Offset by player image width and height.
        float xOffset = this.spriteRenderer.size.x / 2;
        float yOffset = this.spriteRenderer.size.y / 2;
        this.minBounds -= new Vector2(xOffset, yOffset);
        this.maxBounds += new Vector2(xOffset, yOffset);
    }

    private void CheckBounds()
    {
        float xPos = this.transform.localPosition.x;
        float yPos = this.transform.localPosition.y;

        if (!(this.minBounds.x <= xPos && xPos <= this.maxBounds.x)
            || !(this.minBounds.y <= yPos && yPos <= this.maxBounds.y))
        {
            Destroy(this.gameObject);
        }
    }
}
