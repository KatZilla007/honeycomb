/*
 Jonah W. Rabuck
*/

using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BKIdleState : BKState
{
    public BKIdleState(BKController controller) : base(controller) { }

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
