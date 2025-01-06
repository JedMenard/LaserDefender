using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5;

    [SerializeField]
    private float verticalBoundOffset = 0;

    private SpriteRenderer playerSpriteRenderer;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private Vector2 moveVector = new Vector2();

    private void Start()
    {
        this.playerSpriteRenderer = this.GetComponent<SpriteRenderer>();
        this.InitBounds();
    }

    // Update is called once per frame
    private void Update()
    {
        this.Move(Time.deltaTime * this.moveVector);
    }

    private void InitBounds()
    {
        Camera mainCamera = Camera.main;

        // Start with the base values.
        this.minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        this.maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        // Offset by player image width and height.
        float xOffset = this.playerSpriteRenderer.size.x / 2;
        float yOffset = this.playerSpriteRenderer.size.y / 2;
        this.minBounds += new Vector2(xOffset, yOffset);
        this.maxBounds -= new Vector2(xOffset, yOffset + this.verticalBoundOffset);
    }

    private void Move(Vector3 velocityVector)
    {
        Vector3 newPosition = this.transform.position + velocityVector;

        newPosition.x = Mathf.Clamp(newPosition.x, this.minBounds.x, this.maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, this.minBounds.y, this.maxBounds.y);

        this.transform.position = newPosition;
    }

    private void OnMove(InputValue input)
        => this.moveVector = this.moveSpeed * input.Get<Vector2>();
}
