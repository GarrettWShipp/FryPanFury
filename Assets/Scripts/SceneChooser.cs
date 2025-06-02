using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChooser : MonoBehaviour
{
    DungeonMaker dungeon;
    public List<string> basicFights;
    public List<string> eliteFights;
    public string shop;
    public List<string> randomEncounters;

    void Start()
    {
        dungeon = gameObject.GetComponent<DungeonMaker>();
    }
    public void ChooseScenes()
    {
        for (int i = 0; i > dungeon.wholeMap[0].rooms.Count - 1; i++)
        {
            if (i == 0)
            {
                for (int x = 0; x < dungeon.wholeMap[0].rooms[i].doors.Count - 1; x++)
                {
                    int randInt = Random.Range(0, basicFights.Count);
                    dungeon.wholeMap[0].rooms[i].doors[x].scene = basicFights[randInt];
                }
            }
            else if (i == 2)
            {
                dungeon.wholeMap[0].rooms[i].doors[0].scene = shop;
                for (int x = 1; x < dungeon.wholeMap[0].rooms[i].doors.Count - 1; x++)
                {
                    dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                }
            }
            else
            {
                for (int x = 0; x < dungeon.wholeMap[0].rooms[i].doors.Count - 1; x++)
                {
                    dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                }
            }
        }
    }

    public string randomScene()
    {
        int randInt = Random.Range(0, 4);
        if (randInt == 0)
        {
            int randScene = Random.Range(0, basicFights.Count);
            return basicFights[randScene];
        }
        if (randInt == 1)
        {
            int randScene = Random.Range(0, eliteFights.Count);
            return eliteFights[randScene];
        }
        if (randInt == 2)
        {
            return "shop";
        }
        if (randInt == 3)
        {
            int randScene = Random.Range(0, randomEncounters.Count);
            return randomEncounters[randScene];
        }
        return null;
    }

}
