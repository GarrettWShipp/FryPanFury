using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;

public class CombatManager : SimpleStateMachine
{
    //States
    public PlayersTurn player;
    public EnemyTurn enemy;
    public EndCombat end;

    private void Awake()
    {
        states.Add(player);
        states.Add(enemy);
        states.Add(end);

        foreach (SimpleState s in states)
            s.stateMachine = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(nameof(player));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
