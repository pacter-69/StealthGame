using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
 
public class DistanceManager : MonoBehaviour
{
   public int distancia;
    public Boolean aentrado=false;
   public static event Action<int> OnDistanceUpdated;

    private void Awake()
    {
        distancia = 0;
    }

    private void OnDisable()
    {
        aentrado = true;
        PlayerMove.OnMoveUnit -= UpdateDistance;
    }

    private void OnEnable()
    {
        aentrado = true;
        PlayerMove.OnMoveUnit += UpdateDistance;
    }

    private void UpdateDistance(int unidad)
    {
    distancia+=unidad;
    OnDistanceUpdated?.Invoke(((int)distancia));
    }
}