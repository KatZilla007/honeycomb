/*
 Jonah W. Rabuck
*/

using UnityEngine;

public class BKJumpState : BKState
{
    public BKJumpState(BKController controller) : base(controller) { }

    public override void Update()
    {
        if (controller.IsJumping)
        {
            controller.ChangeState(controller.jumpState);
        }
        else if (controller.IsMoving)
        {
            controller.ChangeState(controller.walkState);
        }
    }
}
