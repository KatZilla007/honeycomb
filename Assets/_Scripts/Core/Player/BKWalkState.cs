/*
 Jonah W. Rabuck
*/

using UnityEngine;

public class BKWalkState : BKState
{
    public BKWalkState(BKController controller) : base(controller) { }

    float turnSmoothVelocity;

    public override void Update()
    {
        Vector2 input = controller.MoveInput;
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + controller.CameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(controller.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            controller.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.CharacterController.Move(moveDir.normalized * controller.walkSpeed * Time.deltaTime);
        }
        else
        {
            controller.ChangeState(controller.idleState);
        }
    }
}
