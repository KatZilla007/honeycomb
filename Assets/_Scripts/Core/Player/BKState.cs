/*
 Jonah W. Rabuck
*/

using UnityEngine;

public abstract class BKState
{
    protected BKController controller;
    public BKState(BKController controller)
    {
        this.controller = controller;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
