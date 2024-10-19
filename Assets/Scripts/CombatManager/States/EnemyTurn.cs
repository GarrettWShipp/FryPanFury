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
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextAttack == "Attack")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Attack();
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().AttackedGFX.SetActive(true);
                ((CombatManager)stateMachine).ChangeState(nameof(EndOfTurn));
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextAttack == "Defend")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Defend();
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DefendedGFX.SetActive(true);
                ((CombatManager)stateMachine).ChangeState(nameof(EndOfTurn));
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextAttack == "Buff")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Buff();
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().BuffedGFX.SetActive(true);
                ((CombatManager)stateMachine).ChangeState(nameof(EndOfTurn));
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextAttack == "Debuff")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Debuff();
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DebuffedGFX.SetActive(true);
                ((CombatManager)stateMachine).ChangeState(nameof(EndOfTurn));
            }
            
        }

        if (((CombatManager)stateMachine).combatIsDone)
        {
            ((CombatManager)stateMachine).ChangeState(nameof(EndCombat));
        }
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
