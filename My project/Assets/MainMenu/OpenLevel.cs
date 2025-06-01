using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevelButton : MonoBehaviour
{
    public string levelToLoad = "Level1"; // Replace with your actual scene name

    void OnMouseDown()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
