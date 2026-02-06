using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
 
public class DistanceManager : MonoBehaviour
{
   public float distancia;
    public Boolean aentrado=false;
   public static event Action<int> OnDistanceUpdated;

    private void Awake()
    {
        distancia = 0;
    }

    private void OnDisable()
    {
        aentrado = true;
        PlayerDistanceTracker.OnMoveUnit -= UpdateDistance;
    }

    private void OnEnable()
    {
        aentrado = true;
        PlayerDistanceTracker.OnMoveUnit += UpdateDistance;
    }

    private void UpdateDistance(float unidad)
    {
    distancia+=unidad;
    OnDistanceUpdated?.Invoke(((int)distancia));
    }
}