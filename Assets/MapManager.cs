using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager instance { get; private set; }

    private GameManager m_gameManager;

    private int m_maxshops;
    private int m_minshops;
    private int m_maxEvents;
    private int m_minEvents;
    private int m_maxElites;
    private int m_minElites;
    private int m_maxRoomsOnFloor = 4;
    private int m_minRoomsOnFloor;

    public int numberOfFloors;
    private int m_numOfRooms;

    public GameObject floorPrefab;
    public GameObject roomPrefab;
    public GameObject mapObject;

    Transform floor1;
    Transform floor2;
    Transform room1;
    Transform room2;
    LineRenderer lr;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Make an instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        m_gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        GenerateMap();
        PathRender();
        /*    
        lr.SetPosition(0, new Vector3(0, 0, 0));

        mapObject.transform.GetChild(0).gameObject.SetActive(true);
        */
    }
    

    public void GenerateMap()
    {
        for (int i = 0; i < numberOfFloors; i++)
        {
            GameObject floor = Instantiate(floorPrefab, mapObject.transform);
            floor.name = "Floor " + i.ToString();

            if(i == 0)
            {
                m_minRoomsOnFloor = 1;
                m_numOfRooms = Random.Range(m_minRoomsOnFloor, m_maxRoomsOnFloor);
                for (int j = 0; j < m_numOfRooms; j++)
                {
                    GameObject room = Instantiate(roomPrefab, floor.transform);
                    room.name = "Room " + j.ToString();
                }
            }
            else
            {
                if (m_numOfRooms == 1)
                {
                    m_minRoomsOnFloor = 1;
                }
                else
                {
                    m_minRoomsOnFloor = m_numOfRooms - 1;
                }

                m_numOfRooms = Random.Range(m_minRoomsOnFloor, m_maxRoomsOnFloor);
                for (int j = 0; j < m_numOfRooms; j++)
                {
                    GameObject room = Instantiate(roomPrefab, floor.transform);
                    room.name = "Room " + j.ToString();

                    if(i == m_gameManager.floorsCleared)
                    {
                        room.GetComponent<Button>().interactable = true;
                    }
                    else
                    {
                        room.GetComponent <Button>().interactable = false;
                    }
                }
            }
        }
    }

    public void PathRender()
    {
        for(int i = 0;  i < mapObject.transform.childCount; i++)
        {
            floor1 = mapObject.transform.GetChild(i);

            if (i + 1 < mapObject.transform.childCount)
            {
                floor2 = mapObject.transform.GetChild(i + 1);
            }
            else
            {
                return;
            }

            for (int j = 0; j < floor1.childCount; j++)
            {
                room1 = floor1.GetChild(j);
                lr = room1.AddComponent<LineRenderer>();
                lr.sortingOrder = 1;
                lr.SetPosition(0, new Vector3(room1.position.x, room1.localPosition.y, 0));
            }
            for(int j = 0; j < floor2.childCount; j++)
            {
                room2 = floor2.GetChild(j);
                floor1.GetChild(j).GetComponent<LineRenderer>().SetPosition(1, new Vector3 (room2.position.x, room2.localPosition.y, 0));
            }
        }
    }
}
