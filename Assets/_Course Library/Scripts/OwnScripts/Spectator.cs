using UnityEngine;

public class Spectator : MonoBehaviour
{
    private Animator animator;
    public string animationStateName;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        float randomNormalizedTime = Random.value;
        animator.Play(animationStateName, -1, randomNormalizedTime);
    }
}

