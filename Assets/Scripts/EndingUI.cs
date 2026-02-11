using UnityEngine;
using TMPro;

public class EndingUI : MonoBehaviour
{
    public TextMeshProUGUI dieForEnemiesText;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;

    void Start()
    {
        int dieForEnemies = PlayerPrefs.GetInt("DieForEnemies", 0);
        int lastTime = PlayerPrefs.GetInt("LastTime", 0);
        int bestTime = PlayerPrefs.GetInt("BestTime", 0);

        if (dieForEnemies == 1)
        {
            dieForEnemiesText.text = "Has sido atrapado...\n¡Has perdido!";
            currentTimeText.text = "";
            bestTimeText.text = "";
        }
        else
        {
            dieForEnemiesText.text = "Has llegado al final. ¡Felicidades!"; 
            currentTimeText.text = "Tu tiempo: " + lastTime + " segundos";
            bestTimeText.text = "Mejor tiempo: " + bestTime + " segundos";
        }
    }
}
