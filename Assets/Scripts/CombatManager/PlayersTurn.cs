using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;


[System.Serializable]
public class PlayersTurn : SimpleState
{
    private int m_tempFireDmg;
    private int m_tempDefense;
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
        if(((CombatManager)stateMachine).playerManager.dmgDebuffCounter != 0)
            ((CombatManager)stateMachine).playerManager.dmgDebuffCounter--;
        if (((CombatManager)stateMachine).playerManager.dmgBuffCounter != 0)
            ((CombatManager)stateMachine).playerManager.dmgBuffCounter--;
        if (((CombatManager)stateMachine).playerManager.defDebuffCounter != 0)
            ((CombatManager)stateMachine).playerManager.defDebuffCounter--;
        if (((CombatManager)stateMachine).playerManager.defBuffCounter != 0)
            ((CombatManager)stateMachine).playerManager.defBuffCounter--;

        if (((CombatManager)stateMachine).playerManager.poisonCounter != 0)
        {
            ((CombatManager)stateMachine).playerManager.GetComponent<Health>().Damage(((CombatManager)stateMachine).playerManager.poisonDamage);
            ((CombatManager)stateMachine).playerManager.poisonCounter--;
        }

        if(((CombatManager)stateMachine).playerManager.fireCounter != 0)
        {
            m_tempFireDmg = ((CombatManager)stateMachine).playerManager.fireDmg;
            if (((CombatManager)stateMachine).playerManager.defense > 0)
            {
                m_tempDefense = Mathf.Abs(((CombatManager)stateMachine).playerManager.defense - ((CombatManager)stateMachine).playerManager.fireDmg);
                m_tempFireDmg = Mathf.Abs(((CombatManager)stateMachine).playerManager.fireDmg - ((CombatManager)stateMachine).playerManager.defense);
                ((CombatManager)stateMachine).playerManager.defense = m_tempDefense;
            }
            if(((CombatManager)stateMachine).playerManager.defense < 0)
            {
                ((CombatManager)stateMachine).playerManager.defense = 0;
            }
            if(m_tempFireDmg > 0)
            {
                ((CombatManager)stateMachine).playerManager.GetComponent<Health>().Damage(m_tempFireDmg);
            }
            ((CombatManager)stateMachine).playerManager.fireCounter--;
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
