using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TimeText : MonoBehaviour
{
    private Text label;
    public int currentTime;

    private void Awake()
    {
        label = GetComponent<Text>();
        currentTime = 0;
    }

    private void OnDisable()
    {
        Cronometro.OnTimeUpdated -= UpdateTimeText;
    }

    private void OnEnable()
    {
        Cronometro.OnTimeUpdated += UpdateTimeText;
    }

    private void UpdateTimeText(int tiempo)
    {
        currentTime = tiempo;
        label.text = "tiempo: " + tiempo.ToString() + " seg.";
    }
}