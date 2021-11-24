using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject aiComponent;
    public GameObject playerComponent;

    public void SetAI()
    {
        playerComponent.SetActive(false);
        aiComponent.SetActive(true);
    }

    public void SetPlayer()
    {
        aiComponent.SetActive(false);
        playerComponent.SetActive(true);
    }
}