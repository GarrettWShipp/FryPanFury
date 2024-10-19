using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;


[System.Serializable]
public class EndCombat : SimpleState
{
    public override void OnStart()
    {
        Debug.Log("End Of Combat");
        base.OnStart();
        ((CombatManager)stateMachine).combatStatMenu.SetActive(true);

    }

    public override void UpdateState(float _dt)
    {
        base.UpdateState(_dt);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
