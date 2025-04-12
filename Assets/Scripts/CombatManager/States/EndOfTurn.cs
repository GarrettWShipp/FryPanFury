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

        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            ((CombatManager)stateMachine).enemyCard.GetComponent<CardDisplay>().card = ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextMove;
            ((CombatManager)stateMachine).EnemyMoveSpawnCard();
        }
        
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            

        }
        
    }

    public override void OnExit()
    {
        base.OnExit();
        if (((CombatManager)stateMachine).enemyCards.Length != 0)
            for (int i = 0; i < ((CombatManager)stateMachine).enemyCards.Length; i++)
            {
                ((CombatManager)stateMachine).DestroyGameObject(((CombatManager)stateMachine).enemyCards[i]);
            }
    }
}
