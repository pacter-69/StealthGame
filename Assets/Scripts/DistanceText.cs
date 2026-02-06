using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class DistanceText : MonoBehaviour
{
    private Text label;
    public float distance;

    private void Awake()
    {
        label = GetComponent<Text>();
        distance = 0;
    }

    private void OnDisable()
    {
        PlayerDistanceTracker.OnMoveUnit -= UpdateDistanceText;
    }

    private void OnEnable()
    {
        PlayerDistanceTracker.OnMoveUnit += UpdateDistanceText;
    }

    private void UpdateDistanceText(float distancia)
    {
        distance += distancia;
        label.text = "distancia: " + (int)distance + "m";
    }
}