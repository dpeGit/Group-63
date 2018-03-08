using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class IdleState : IState
{
    /// A reference to the parent
    private Enemy parent;

    /// This is called whenever we enter the state
    /// <param name="parent">The parent enemy</param>
    public void Enter(Enemy parent)
    {
        this.parent = parent;
    
        this.parent.Reset();
    }

    /// This is called whenever we exit the state
    public void Exit()
    {
        
    }

    /// This is called as long as we are inside the state
    public void Update()
    {
        Debug.Log("Idle");

        //Change into follow state if the player is close
        if (parent.MyTarget != null)//If we have a target , the nwe need to follow it.
        {
            parent.ChangeState(new FollowState());
        }
    }
}
