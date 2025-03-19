using UnityEngine;

public class PlayerAnimationController
{
    public enum ID
    {
        Stand = 1,
        Move = 2,
        Run = 3,
        Air = 4,
        Jump = 5,
        Sneak = 6,
        SneakSlow = 7,
    }

    private readonly Animator animator;

    public PlayerAnimationController(Transform playerModelVRM)
    {
        animator = playerModelVRM.GetComponent<Animator>();
    }

    public void ChangeState(ID id)
    {
        animator.SetInteger("ID", (int)id);
        animator.SetTrigger("ChangeState");
    }

    public void Stand() => ChangeState(ID.Stand);
    public void Move() => ChangeState(ID.Move);
    public void Run() => ChangeState(ID.Run);
    public void Air() => ChangeState(ID.Air);
    public void Jump() => ChangeState(ID.Jump);
    public void Sneak() => ChangeState(ID.Sneak);
    public void SneakSlow() => ChangeState(ID.SneakSlow);

    // public void PlayAnimationInstant(string stateName)
    // {
    //     animator.Play(stateName);
    // }

    // public void Stand() => PlayAnimationInstant("NormalStand");
    // public void Move() => PlayAnimationInstant("NormalMove");
    // public void Run() => PlayAnimationInstant("NormalRun");
    // public void Air() => PlayAnimationInstant("NormalAir");

    // public void Stand()
    // {
    //     // animator.Play("NormalStand");
    //     animator.SetInteger("ID", 1);
    //     // animator.SetInteger("ID", 0);
    // }
    // public void Move()
    // {
    //     animator.SetInteger("ID", 2);
    //     // animator.SetInteger("ID", 0);
    //     // animator.Play("HumanM@Walk01_Forward");
    // }
    // public void Run()
    // {
    //     animator.SetInteger("ID", 3);
    //     // animator.SetInteger("ID", 0);
    //     // animator.Play("HumanF@Run01_Forward");
    // }
    // public void Air()
    // {
    //     animator.SetInteger("ID", 4);
    //     // animator.SetInteger("ID", 0);
    //     // animator.Play("HumanF@Fall01");
    // }
}