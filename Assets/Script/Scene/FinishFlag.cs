using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    public int nextSceneIndex; // choose scene in Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNext();
        }
    }

    void LoadNext()
    {
        Time.timeScale = 1f; // important if paused
        SceneManager.LoadScene(nextSceneIndex);
    }
}