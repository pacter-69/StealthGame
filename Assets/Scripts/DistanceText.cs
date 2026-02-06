using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class DistanceText : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void OnDisable()
    {
        DistanceManager.OnDistanceUpdated -= UpdateDistanceText;
    }

    private void OnEnable()
    {
        DistanceManager.OnDistanceUpdated += UpdateDistanceText;
    }

    private void UpdateDistanceText(int distancia)
    {
        label.text = "distancia: " + distancia.ToString() + "cm";
    }
}