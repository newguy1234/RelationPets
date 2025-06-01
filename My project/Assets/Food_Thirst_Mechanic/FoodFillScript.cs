using UnityEngine;

public class FoodBarFill : MonoBehaviour
{
    [Range(0f, 1f)]
    public float foodPercent = 1f; // Fill percent

    public Transform fillObject; // The brown bar sprite (child of this object)
    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        if (fillObject == null)
        {
            Debug.LogError("Fill object not assigned!");
            return;
        }

        initialScale = fillObject.localScale;
        initialPosition = fillObject.localPosition;
        SetFill(foodPercent); // Ensure it sets initially
    }

    public void SetFill(float percent)
    {
        foodPercent = Mathf.Clamp01(percent);

        Vector3 newScale = initialScale;
        newScale.x = foodPercent;
        fillObject.localScale = newScale;

        // If pivot isn't left, offset position to keep bar filling from left
        float fillWidth = initialScale.x; // 1.0 if originally full
        float offset = (1 - foodPercent) * fillWidth * 0.5f;
        Vector3 newPosition = initialPosition;
        newPosition.x = initialPosition.x - offset;
        fillObject.localPosition = newPosition;
    }
}
