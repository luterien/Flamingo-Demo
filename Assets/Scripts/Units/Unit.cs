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
    public Transform hands;

    private void Awake()
    {
        aiComponent.SetActive(false);
        playerComponent.SetActive(false);
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
}
