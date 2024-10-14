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
        if(m_enemyManager.currentAttack == "Attack")
        {
            m_enemyManager.attacking.SetActive(true);
        }
        else
            m_enemyManager.attacking.SetActive(false);

        if (m_enemyManager.currentAttack == "Defend")
        {
            m_enemyManager.defending.SetActive(true);
        }
        else
            m_enemyManager.defending.SetActive(false);

        if (m_enemyManager.currentAttack == "Debuff")
        {

        }
        if (m_enemyManager.currentAttack == "Buff")
        {

        }
        if (m_enemyManager.currentAttack == "Heal")
        {

        }
    }
}
