using UnityEngine;

public class SpriteButtonClick : MonoBehaviour
{
    public FoodBarFill foodBar;
    public float increaseAmount = 0.1f;

    void OnMouseDown()
    {
        if (foodBar != null)
        {
            float newPercent = foodBar.foodPercent + increaseAmount;
            foodBar.SetFill(newPercent);
        }
    }
}
