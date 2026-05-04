using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFlag : MonoBehaviour
{
    public int resultSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishGame();
        }
    }

    void FinishGame()
    {
        Time.timeScale = 1f;

        if (GameTimer.instance != null)
            GameTimer.instance.StopTimer();

        SceneManager.LoadScene(resultSceneIndex);
    }
}