using UnityEngine;

public class MeleeEnemy : AbstractEnemy
{
    [Range(0.1f, 10)]
    public float attackRange = 2;
    [Range(1, 100)]
    public int damage = 5;

    RunTo runState;
    Attack attackState;
    Stunned stunnedState;
    RotateTo rotateState;

    private void Start()
    {
        base.Start();
        runState = new RunTo(this);
        attackState = new Attack(this);
        stunnedState = new Stunned(this);
        rotateState = new RotateTo(this);

        stateMachine.startingState(runState);
    }

    public override void updateState()
    {
        if (dead == true) return;

        if (stunned == true)
        {
            stateMachine?.setState(stunnedState);
        }
        else
        {
            if (Vector3.Angle(transform.forward, player.position - transform.position) > 20)
            {
                //Debug.Log(Vector3.Angle(transform.forward, player.position - transform.position));
                stateMachine?.setState(rotateState);
            }
            else
            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                stateMachine?.setState(runState);
            }
            else
            if (Vector3.Angle(transform.forward, player.position - transform.position) > 10)
            {
                stateMachine?.setState(rotateState);
            }
            else
            {
                //Debug.Log("Attack");
                stateMachine?.setState(attackState);
            }
        }

        stateMachine?.update();
    }

    public void dealDamage()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Health playerHP = player.GetComponent<Health>();
            if (playerHP != null)
                playerHP.hpDecrease(damage);
        }
    }
}
