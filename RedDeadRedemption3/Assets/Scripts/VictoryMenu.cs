using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Replay()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
