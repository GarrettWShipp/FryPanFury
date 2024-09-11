using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;

public class PlayersTurn : SimpleState
{
    public CardManager cardManager;
    public override void OnStart()
    {
        base.OnStart();

        cardManager.DrawCard();
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
