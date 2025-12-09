using UnityEngine;

public class RotateTo : IState
{
    AbstractEnemy enemy;

    float updatesPerSecond;

    public RotateTo(AbstractEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void enter()
    {
        enemy.stop(true);
        updatesPerSecond = enemy.updatesPerSeconds;
        enemy.updatesPerSeconds = 60;
    }

    public void update()
    {
        enemy.rotateTo(enemy.Player.position);
    }

    public void exit()
    {
        enemy.stop(false);
        enemy.updatesPerSeconds = updatesPerSecond;
    }
}
