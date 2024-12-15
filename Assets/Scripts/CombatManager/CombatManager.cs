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
    [HideInInspector] public PlayerManager playerManager;
    public GameManager gameManager;
    public bool combatIsDone = false;
    public GameObject combatStatMenu;
    public GameObject nextButton;
    public GameObject altNextButton;
    public GameObject enemyCard;
    private GameObject m_enemyMoves;
    private int counter = 0;
    [HideInInspector] public GameObject[] enemyCards;

    private void Awake()
    {
        states.Add(player);
        states.Add(enemy);
        states.Add(endOfTurn);
        states.Add(finishCombat);

        foreach (SimpleState s in states)
            s.stateMachine = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        combatStatMenu.active = false;
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        ChangeState(nameof(PlayersTurn));
        m_enemyMoves = GameObject.FindWithTag("EnemyMove");
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            combatIsDone = true;
            combatStatMenu.active = true;
            return;
        }
        else
        {
            combatStatMenu.active = false;
            combatIsDone = false;
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i >= gos.Length; i++)
            {
                if (gos[i].active == false)
                {
                    enemies.Append(gos[i]);
                }
            }
        }

        enemyCards = GameObject.FindGameObjectsWithTag("EnemyCards");
        
    }
    public void EnemyMoveSpawnCard()
    {
        Instantiate(enemyCard, m_enemyMoves.transform);
    }
    public void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
