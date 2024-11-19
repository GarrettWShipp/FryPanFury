using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using Unity.Collections.LowLevel.Unsafe;


[System.Serializable]
public class EndCombat : SimpleState
{
    public override void OnStart()
    {
        Debug.Log("End Of Combat");
        base.OnStart();
        ((CombatManager)stateMachine).combatStatMenu.SetActive(true);
        ((CombatManager)stateMachine).cardManager.DiscardAll();
        ((CombatManager)stateMachine).cardManager.ReshuffleCards();



        ((CombatManager)stateMachine).gameManager.health = ((CombatManager)stateMachine).playerManager.GetComponent<Health>().currentHealth;
        ((CombatManager)stateMachine).gameManager.handSize = ((CombatManager)stateMachine).playerManager.GetComponent<PlayerManager>().totalHandSize;
        ((CombatManager)stateMachine).gameManager.cards = ((CombatManager)stateMachine).cardManager.GetComponent<CardManager>().Deck;

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
