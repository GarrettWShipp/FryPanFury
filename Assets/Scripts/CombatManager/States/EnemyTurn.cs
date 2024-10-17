using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using System.Linq;

[System.Serializable]
public class EnemyTurn : SimpleState
{
    public override void OnStart()
    {
        base.OnStart();
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().defense = 0;
            
        }
    }

    public override void UpdateState(float _dt)
    {
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Attack")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Attack();
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Defend")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Defend();
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Heal")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Heal();
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Buff")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Buff();
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Debuff")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Debuff();
            }
            
        }
        ((CombatManager)stateMachine).ChangeState(nameof(PlayersTurn));
        base.UpdateState(_dt);
    }

    public override void OnExit()
    {
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().counter == ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().maxCounter + 1)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().counter = 0;
            }
            else
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().counter++;
        }
        base.OnExit();
    }
}
