using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using SuperPupSystems.StateMachine;
using System.Linq;

public class CombatManager : SimpleStateMachine
{
    //States
    public PlayersTurn player;
    public EnemyTurn enemy;
    public EndOfTurn endOfTurn;
    public EndCombat finishCombat;

    //Variables
    public GameObject[] enemies;
    public CardManager cardManager;
    public PlayerManager playerManager;
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

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i >= gos.Length; i++)
        {
            if (gos[i].active == false)
            {
                enemies.Append(gos[i]);
            }
        }
        if (enemies.Length <= 0)
        {
            ChangeState(nameof(EndCombat));
        }
    }
}
