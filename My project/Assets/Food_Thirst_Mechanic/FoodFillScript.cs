using UnityEngine;

public class FoodBarFill : MonoBehaviour
{
    [Range(0f, 1f)]
    public float foodPercent = 1f; // from 0 (empty) to 1 (full)

    public Transform fillObject; // Assign the brown fill bar
    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        if (fillObject == null)
        {
            Debug.LogError("Fill object not assigned.");
            return;
        }

        initialScale = fillObject.localScale;
        initialPosition = fillObject.localPosition;
    }

    void Update()
    {
        SetFill(foodPercent);
    }

    public void SetFill(float percent)
    {
        percent = Mathf.Clamp01(percent);

        // Scale the fill on X
        Vector3 scale = initialScale;
        scale.x = percent;
        fillObject.localScale = scale;

        // Adjust position so left edge stays fixed
        float offsetX = (1 - percent) * 0.5f * initialScale.x;
        Vector3 pos = initialPosition;
        pos.x = initialPosition.x - offsetX;
        fillObject.localPosition = pos;
    }
}
