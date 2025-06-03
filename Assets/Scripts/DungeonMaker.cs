using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Doors
{
    public string scene;
}

[System.Serializable]
public class Rooms
{
    public List<Doors> doors = new();
    public int randInt = Random.Range(2, 4);
}

[System.Serializable]
public class Dungeons
{
    public List<Rooms> rooms = new();
}
public class DungeonMaker : SceneChooser
{
    public List<Dungeons> wholeMap;
    public int numOfRooms;
    public int roomCounter = 0;
    public bool isDone;

    void Start()
    {
        Dungeons newDungeon = new();
        wholeMap.Add(newDungeon);

    }

    void Update()
    {
        for (int i = 0; i <= numOfRooms - 1; i++)
        {
            if (wholeMap[0].rooms.Count <= numOfRooms - 1)
            {
                Rooms newRoom = new();
                wholeMap[0].rooms.Add(newRoom);
            }
        }
        for (int i = 0; i <= wholeMap[0].rooms.Count - 1; i++)
        {
            if (wholeMap[0].rooms[i].doors.Count < wholeMap[0].rooms[i].randInt)
            {
                Doors newDoor = new();
                wholeMap[0].rooms[i].doors.Add(newDoor);
            }
        }
        ChooseScenes();
    }
}
