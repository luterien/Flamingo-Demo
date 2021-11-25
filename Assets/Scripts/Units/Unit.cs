using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Components")]
    public GameObject aiComponent;
    public GameObject playerComponent;

    [Header("References")]
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;

    [Header("Animation")]
    public Animator animator;

    private void Awake()
    {
        ActivateAI();
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
