using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Components")]
    public GameObject aiComponent;
    public GameObject playerComponent;

    [Header("References")]
    public Transform ballSpawnPoint;
    [Space]
    public Transform model;

    private void Awake()
    {
        Deactivate();
    }

    public void ActivatePlayer()
    {
        aiComponent.SetActive(false);
        playerComponent.SetActive(true);
    }

    public void ActivateAI()
    {
        playerComponent.SetActive(false);
        aiComponent.SetActive(true);
    }

    public void Deactivate()
    {
        aiComponent.SetActive(false);
        playerComponent.SetActive(false);
    }
}
