using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    public void PlayAgain()
    {
        // reset timer
        if (GameTimer.instance != null)
            GameTimer.instance.ResetTimer();

        // reset coins
        if (CoinManager.instance != null)
            CoinManager.instance.ResetCoins();

        Time.timeScale = 1f;

        SceneManager.LoadScene(1); // Level1
    }

    public void GoToMenu()
    {
        // reset timer
        if (GameTimer.instance != null)
            GameTimer.instance.ResetTimer();

        // reset coins
        if (CoinManager.instance != null)
            CoinManager.instance.ResetCoins();

        Time.timeScale = 1f;

        SceneManager.LoadScene(0); // Main Menu scene
    }
}