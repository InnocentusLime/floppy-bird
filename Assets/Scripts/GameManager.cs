using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private int score;

    public void OnScore()
    {
        Debug.Log("Reward!");
        score++;
    }

    public void OnGameOver()
    {
        isGameOver = true;
        Debug.Log(string.Format("You died! Score: {0}", score));
    }
    public void OnFly(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        if (isGameOver)
        {
            Debug.Log("The game will now reset");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
