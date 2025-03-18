using UnityEngine;

public class PlayerAnimationController
{
    private Animator animator;

    public PlayerAnimationController(Transform playerModelVRM)
    {
        animator = playerModelVRM.GetComponent<Animator>();
    }

    public void Stand()
    {
        animator.Play("HumanM@Idle01");
    }
    public void Move()
    {
        animator.Play("HumanM@Walk01_Forward");
    }
    public void Run()
    {
        animator.Play("HumanF@Run01_Forward");
    }
    public void Air()
    {
        animator.Play("HumanM@Fall01");
    }
}