using System;
using System.Collections;
using UnityEngine;


public class QuestEndedAnimationTrigger : MonoBehaviour
{
    private Animator animator;
    private BoxCollider collider;
    [SerializeField] private GameObject goToMove;
    [SerializeField] private Transform finalPosition;
    [SerializeField] private float speed;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        QuestComponent.OnQuestEnd += TriggerAnimation;
    }

    private void TriggerAnimation()
    {
        animator.SetBool("QuestCompleted", true);
    }

    public void WaitForAnimation()
    {
        collider.enabled = false;
        LeanTween.move(goToMove, finalPosition.position, speed);
    }

    public void ReturnToIdle()
    {
        animator.SetBool("QuestCompleted", false);
    }
}

