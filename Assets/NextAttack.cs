using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAttack : MonoBehaviour
{
    private EnemyManager m_enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        m_enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_enemyManager.nextAttack == "Attack")
        {
            m_enemyManager.attacking.SetActive(true);
        }
        else
            m_enemyManager.attacking.SetActive(false);

        if (m_enemyManager.nextAttack == "Defend")
        {
            m_enemyManager.defending.SetActive(true);
        }
        else
            m_enemyManager.defending.SetActive(false);

        if (m_enemyManager.nextAttack == "Buff" || m_enemyManager.nextAttack == "Debuff")
        {
            m_enemyManager.spell.SetActive(true);
        }
        else
            m_enemyManager.spell.SetActive(false);

        if (m_enemyManager.nextAttack == "Heal")
        {

        }
    }
}
