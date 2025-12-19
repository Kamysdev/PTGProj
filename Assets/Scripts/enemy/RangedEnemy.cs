using UnityEngine;

public class RangedEnemy : AbstractEnemy
{
    [Range(2, 50)]
    public float shootRange = 10;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootCooldown = 1.5f;

    float lastShootTime;

    RunTo runState;
    RotateTo rotateState;
    Stunned stunnedState;

    private void Start()
    {
        base.Start();

        runState = new RunTo(this);
        rotateState = new RotateTo(this);
        stunnedState = new Stunned(this);

        stateMachine.startingState(runState);
    }

    public override void updateState()
    {
        if (dead) return;

        if (stunned)
        {
            stateMachine.setState(stunnedState);
        }
        else if (Vector3.Distance(transform.position, player.position) > shootRange)
        {
            stateMachine.setState(runState);
        }
        else
        {
            stateMachine.setState(rotateState);

            if (Time.time - lastShootTime > shootCooldown)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }

        stateMachine.update();
    }

    void Shoot()
    {
        // Логика выстрела. Я не придумал
        Debug.Log("Pew-Pew");
    }
}

