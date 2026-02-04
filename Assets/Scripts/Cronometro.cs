using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Cronometro : MonoBehaviour
{
    public float tiempo=0;

    public static event Action<int> OnTimeUpdated;
    

    void Update()
    {
        tiempo += Time.deltaTime;
        OnTimeUpdated?.Invoke(((int)tiempo));
    }
}