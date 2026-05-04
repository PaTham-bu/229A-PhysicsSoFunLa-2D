using UnityEngine;
using TMPro;

public class ResultUI : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text coinText;

    void Start()
    {
        //  TIME
        if (GameTimer.instance != null)
        {
            float time = GameTimer.instance.GetTime();

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            timeText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

        //  COINS
        if (CoinManager.instance != null)
        {
            coinText.text = "Coins: " + CoinManager.instance.coins.ToString();
        }
    }
}