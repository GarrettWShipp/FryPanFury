using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;

[System.Serializable]
public class EnemyTurn : SimpleState
{
    private int counter = 1;
    public override void OnStart()
    {
        base.OnStart();
        ((CombatManager)stateMachine).enemyManager.defense = 0;
    }

    public override void UpdateState(float _dt)
    {
        if (counter == 1)
        {
            Debug.Log("Attack");
            ((CombatManager)stateMachine).playerManager.GetComponent<Health>().Damage(2);
            counter++;
            ((CombatManager)stateMachine).ChangeState(nameof(PlayersTurn));
        }
        else if (counter == 2) 
        {
            Debug.Log("Defend");
            ((CombatManager)stateMachine).enemyManager.defense = 1;
            counter--;
            ((CombatManager)stateMachine).ChangeState(nameof(PlayersTurn));
        }
        base.UpdateState(_dt);
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("End turn");
    }
}
