using UnityEngine;
using TMPro;

public class CoinUIBinder : MonoBehaviour
{
    public TMP_Text coinText;

    void Start()
    {
        CoinManager.instance.BindUI(coinText);
    }
}