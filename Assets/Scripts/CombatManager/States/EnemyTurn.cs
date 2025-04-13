using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;

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
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            ((CombatManager)stateMachine).enemyCard.GetComponent<CardDisplay>().card = ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().nextMove;
            ((CombatManager)stateMachine).EnemyMoveSpawnCard();
        }
    }

    public override void UpdateState(float _dt)
    {
        for (int i = 0; i < ((CombatManager)stateMachine).enemies.Length; i++)
        {
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.attack)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Attack();
                
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.defense)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Defend();
                
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.defBuff)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DefBuff();
                
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.dmgBuff)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DmgBuff();

            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.defDebuff)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DefDebuff();
                
            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.dmgDebuff)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().DmgDebuff();

            }
            if (((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().infoType.poisonous)
            {
                ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Poison();

            }

        }
        ((CombatManager)stateMachine).ChangeState(nameof(PlayersTurn));

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
            ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().movelist = ((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().Shift(((CombatManager)stateMachine).enemies[i].GetComponent<EnemyManager>().movelist);
        }
        base.OnExit();
    }
}
