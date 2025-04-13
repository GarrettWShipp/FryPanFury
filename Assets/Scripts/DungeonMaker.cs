using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Doors
{
    public List<int> scenes;
}
[System.Serializable]
public class Rooms
{
    public List<Doors> doors;
}
[System.Serializable]
public class Dungeons
{
    public List<Rooms> rooms;
}
public class DungeonMaker : MonoBehaviour
{
    public List<Dungeons> wholeMap;
    public int numOfRooms;
    public Dungeons dungeon;
    public Rooms room;
    public Doors door;
    public List<string> sceneNames;
    // Start is called before the first frame update
    void Start()
    {
        wholeMap.Add(dungeon);
        for (int i = 0; i <= numOfRooms - 1; i++)
        {
            wholeMap[0].rooms.Add(room);
        }
        for(int i = 0; i <= dungeon.rooms.Count; i++)
        {
            int randInt = Random.Range(2, 3);
            if (dungeon.rooms[i].doors.Count < randInt)
                dungeon.rooms[i].doors.Add(door);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
