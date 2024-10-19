using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;

[System.Serializable]
public class EndOfTurn : SimpleState
{
    
    public override void OnStart()
    {
        base.OnStart();
        Debug.Log("End turn display");

        ((CombatManager)stateMachine).nextButton.SetActive(false);
        ((CombatManager)stateMachine).altNextButton.SetActive(true);
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Attack")
            {

            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().currentAttack == "Defend")
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Defend();
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
        
    }

    public override void OnExit()
    {
        base.OnExit();
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {

        }
        

            ((CombatManager)stateMachine).nextButton.SetActive(true);
        ((CombatManager)stateMachine).altNextButton.SetActive(false);
    }
}
