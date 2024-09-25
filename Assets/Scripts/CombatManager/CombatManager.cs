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
    public EndOfTurn endOfTurn;
    public EndCombat finishCombat;

    //Variables
    public CardManager cardManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public GameObject combatStatsMenu;

    private void Awake()
    {
        states.Add(player);
        states.Add(enemy);
        states.Add(finishCombat);

        foreach (SimpleState s in states)
            s.stateMachine = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(nameof(PlayersTurn));

        enemyManager.attacking.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            ChangeState(nameof(EndCombat));
        }
    }
}
