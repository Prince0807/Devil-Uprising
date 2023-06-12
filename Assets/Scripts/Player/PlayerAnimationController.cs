using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", controller.velocity.magnitude);
    }
}
