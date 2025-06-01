using UnityEngine;

public class PenguinScriptMain : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float directionChangeInterval = 2f;
    public bool facingRight = true;

    private float timer;
    private int direction; // -1 = left, 1 = right

    public Transform leftWallCheck;  // Assign in Inspector
    public Transform rightWallCheck; // Assign in Inspector
    public float wallCheckDistance = 0.1f;
    public LayerMask wallLayer;      // Assign in Inspector

    void Start()
    {
        ChooseRandomDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // Move penguin
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Check for wall collisions
        if ((direction == -1 && IsHittingWall(leftWallCheck)) ||
            (direction == 1 && IsHittingWall(rightWallCheck)))
        {
            TurnAround();
        }

        // Random direction change on timer
        if (timer <= 0)
        {
            ChooseRandomDirection();
        }
    }

    void ChooseRandomDirection()
    {
        direction = Random.Range(0, 2) == 0 ? -1 : 1;
        facingRight = direction == 1;
        timer = directionChangeInterval;
    }

    void TurnAround()
    {
        direction *= -1;
        facingRight = direction == 1;
        timer = directionChangeInterval; // reset timer
    }

    bool IsHittingWall(Transform checkPoint)
    {
        return Physics2D.Raycast(checkPoint.position, Vector2.right * direction, wallCheckDistance, wallLayer);
    }
}
