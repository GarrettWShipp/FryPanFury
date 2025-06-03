using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChooser : MonoBehaviour
{
    public DungeonMaker dungeon;
    public List<string> basicFights;
    public List<string> eliteFights;
    public string shop;
    public List<string> randomEncounters;
    public void ChooseScenes()
    {
        dungeon = gameObject.GetComponent<DungeonMaker>();
        for (int i = 0; i < dungeon.wholeMap[0].rooms.Count; i++)
        {
            if (i == 0)
            {
                for (int x = 0; x < dungeon.wholeMap[0].rooms[i].doors.Count; x++)
                {
                    int randInt = Random.Range(0, basicFights.Count);
                    if(dungeon.wholeMap[0].rooms[i].doors[x].scene == null)
                        dungeon.wholeMap[0].rooms[i].doors[x].scene = basicFights[randInt];
                }
            }
            else if (i == 2)
            {
                dungeon.wholeMap[0].rooms[i].doors[0].scene = shop;
                for (int x = 1; x < dungeon.wholeMap[0].rooms[i].doors.Count; x++)
                {
                    if (dungeon.wholeMap[0].rooms[i].doors[x].scene == null)
                    {
                        dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                        while (dungeon.wholeMap[0].rooms[i].doors[x].scene == "shop")
                        {
                            Debug.Log("redo room:" + i + " door: " + x + " old scene: " + dungeon.wholeMap[0].rooms[i].doors[x].scene);
                            dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                        }
                    }  
                    
                }
            }
            else
            {
                for (int x = 0; x < dungeon.wholeMap[0].rooms[i].doors.Count; x++)
                {
                    if (dungeon.wholeMap[0].rooms[i].doors[x].scene == null)
                    {
                        dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                        
                        while (dungeon.wholeMap[0].rooms[i].doors[0].scene == shop && dungeon.wholeMap[0].rooms[i].doors[x].scene == shop && x != 0)
                        {
                            Debug.Log("redo room:" + i + " door: " + x + " old scene: " + dungeon.wholeMap[0].rooms[i].doors[x].scene);
                            dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                        }
                        while (dungeon.wholeMap[0].rooms[i].doors[1].scene == shop && dungeon.wholeMap[0].rooms[i].doors[x].scene == shop && dungeon.wholeMap[0].rooms[i].doors.Count == 3 && x != 1)
                        {
                            Debug.Log("redo room:" + i + " door: " + x + " old scene: " + dungeon.wholeMap[0].rooms[i].doors[x].scene);
                            dungeon.wholeMap[0].rooms[i].doors[x].scene = randomScene();
                        }
                    }
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
        else if (randInt == 1)
        {
            int randScene = Random.Range(0, eliteFights.Count);
            return eliteFights[randScene];
        }
        else if (randInt == 2)
        {
            return shop;
        }
        else
        {
            int randScene = Random.Range(0, randomEncounters.Count);
            return randomEncounters[randScene];
        }
    }

}
