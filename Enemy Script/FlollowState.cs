using UnityEngine;

/// The enemy's follow state
class FollowState : IState
{
    /// A reference to the parent
    private Enemy parent;

    /// This is called whenever we enter the state
    /// <param name="parent">The parent enemy</param>
    public void Enter(Enemy parent)
    {
        this.parent = parent;
    }

    /// This is called whenever we exit the state
    public void Exit()
    {
        parent.Direction = Vector2.zero;
    }

    /// This is called as long as we are inside the state
    public void Update()
    {
        Debug.Log("Follow");

        if (parent.MyTarget != null)//As long as we have a target, then we need to keep moving
        {
            //Find the target's direction
            parent.Direction = (parent.MyTarget.transform.position - parent.transform.position).normalized;

            //Moves the enemy towards the target
            parent.transform.position = Vector2.MoveTowards(parent.transform.position, parent.MyTarget.position, parent.Speed * Time.deltaTime);

            float distance = Vector2.Distance(parent.MyTarget.position, parent.transform.position);

            if (distance <= parent.MyAttackRange)
            {
                parent.ChangeState(new AttackState());
            }

        }
        if (!parent.InRange)
        {
            parent.ChangeState(new EvadeState());
        } //if we don't have a target, then we need to go back to idle.
       
    }
}
