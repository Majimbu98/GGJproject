using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TransitionComponent : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (sceneName == null) return;
            FadeImage.Instance.FadeAndLoad(sceneName);
        }
    }
}

