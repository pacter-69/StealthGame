using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class TimeText : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
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
        label.text = "TIEMPO: " + tiempo.ToString() + " segundos";
    }
}