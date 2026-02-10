using UnityEngine;
using TMPro;

public class EndingUI : MonoBehaviour
{
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        int lastTime = PlayerPrefs.GetInt("LastTime", 0);
        int bestTime = PlayerPrefs.GetInt("BestTime", 0);

        currentTimeText.text = "Tiempo: " + lastTime + " seg.";
        bestTimeText.text = "Mejor tiempo: " + bestTime + " seg.";
    }
}
