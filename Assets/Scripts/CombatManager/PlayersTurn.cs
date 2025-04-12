using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;


[System.Serializable]
public class PlayersTurn : SimpleState
{
    public override void OnStart()
    {
        Debug.Log("Players turn");
        base.OnStart();
        ((CombatManager)stateMachine).playerManager.curMana = ((CombatManager)stateMachine).playerManager.mana;
        ((CombatManager)stateMachine).playerManager.defense = 0;
        ((CombatManager)stateMachine).cardManager.DrawCard(((CombatManager)stateMachine).playerManager.totalHandSize);
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
        if (((CombatManager)stateMachine).combatIsDone)
        {
            ((CombatManager)stateMachine).ChangeState(nameof(EndCombat));
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        if(((CombatManager)stateMachine).playerManager.debuffCounter != 0)
            ((CombatManager)stateMachine).playerManager.debuffCounter--;
        if (((CombatManager)stateMachine).playerManager.buffCounter != 0)
            ((CombatManager)stateMachine).playerManager.buffCounter--;
        if (((CombatManager)stateMachine).playerManager.poisonCounter != 0)
        {
            ((CombatManager)stateMachine).playerManager.GetComponent<Health>().Damage(((CombatManager)stateMachine).playerManager.poisonDamage);
            ((CombatManager)stateMachine).playerManager.poisonCounter--;
        }

        if (((CombatManager)stateMachine).enemyCards.Length != 0)
            for (int i = 0; i < ((CombatManager)stateMachine).enemyCards.Length; i++)
            {
                ((CombatManager)stateMachine).DestroyGameObject(((CombatManager)stateMachine).enemyCards[i]);
            }
        Debug.Log("End turn");
        ((CombatManager)stateMachine).cardManager.DiscardAll();
    }
}
