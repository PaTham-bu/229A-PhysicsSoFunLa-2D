using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static GameTimer instance;

    private TMP_Text timerText;

    private float timeElapsed = 0f;
    private bool isRunning = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TMP_Text[] texts = FindObjectsOfType<TMP_Text>();

        foreach (var t in texts)
        {
            if (t.name == "TimerText")
            {
                timerText = t;
                break;
            }
        }
    }

    void Update()
    {
        if (!isRunning || timerText == null) return;

        timeElapsed += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        Debug.Log(timerText);
    }
}