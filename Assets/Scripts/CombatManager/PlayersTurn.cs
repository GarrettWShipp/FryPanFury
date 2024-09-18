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
        base.OnStart();
        ((CombatManager)stateMachine).playerManager.curMana = ((CombatManager)stateMachine).playerManager.mana;
        ((CombatManager)stateMachine).playerManager.defense = 0;
    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
    }

    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("End turn");
        ((CombatManager)stateMachine).cardManager.DiscardAll();
    }
}
