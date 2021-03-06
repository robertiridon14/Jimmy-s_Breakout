using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{
    [SerializeField] private int xSize;
    [SerializeField] private int ySize;

 //   [SerializeField] private int[] RenderedTilesX;
 //   [SerializeField] private int[] RenderedTilesY;

    [SerializeField] private int doorFront;
    [SerializeField] private int doorBack;
    [SerializeField] private int doorLeft;
    [SerializeField] private int doorRight;

    [SerializeField] private bool windowFront;
    [SerializeField] private bool windowBack;
    [SerializeField] private bool windowLeft;
    [SerializeField] private bool windowRight;

    [SerializeField] private float StairOpenX;
    [SerializeField] private float StairOpenY;
    [SerializeField] private int FloorNr;

    [SerializeField] private GameObject[] RoomObject;
    [SerializeField] private Vector3[] ObjectLocations;
    [SerializeField] private Quaternion[] ObjectRotation;

    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Window;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Floor;

    private GameObject WallParent;
    private GameObject FloorParent;

    private List<GameObject> room;

    private GameObject newFloor;

    private Vector3 NewPosition;

    private float WallHeight = 4;
    private float FloorSize = 4;

    private int index = 0;


    protected void CreateFloor()
    {
        FloorParent = new GameObject();
        FloorParent.name = "Floor";
        ///Create floor
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                if (!(StairOpenX - 1 == i && StairOpenY - 1 == j))
                {
                        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));
                        NewPosition.x = j * FloorSize;
                        NewPosition.z = i * FloorSize;
                        NewPosition.y = WallHeight * FloorNr;
                        newFloor.transform.parent = FloorParent.transform;
                }
            }
        }
        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        newFloor.transform.parent = FloorParent.transform;

        ///Create roof
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                if (!(StairOpenX - 1 == i && StairOpenY - 1 == j))
                {

                        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(180.0f, 0.0f, 0.0f));
                        NewPosition.x = j * FloorSize;
                        NewPosition.z = i * FloorSize + FloorSize;
                        NewPosition.y = WallHeight * FloorNr + WallHeight;
                        newFloor.transform.parent = FloorParent.transform;
                }
            }
        }
        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(180.0f, 0.0f, 0.0f));
        newFloor.transform.parent = FloorParent.transform;

    }
    protected void CreateWalls()
    {
        this.room = new List<GameObject>();
        this.WallParent = new GameObject();
        WallParent.name = "Walls";
        ///Create front wall
        for (int i = 0; i < xSize; i++)
        {
            if (i == doorFront - 1)
            {
                Door = Instantiate(Door, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Door.transform.parent = WallParent.transform;
            }
            else if (windowFront)
            {
                Window = Instantiate(Window, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Window.transform.parent = WallParent.transform;
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Wall.transform.parent = WallParent.transform;
            }
        }
        ///Create Back wall
        for (int j = 0; j < xSize; j++)
        {
            if (doorBack - 1 == j)
            {
                Door = Instantiate(Door, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Door.transform.parent = WallParent.transform;
            }
            else if (windowBack)
            {
                Window = Instantiate(Window, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Window.transform.parent = WallParent.transform;
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
                Wall.transform.parent = WallParent.transform;
            }
        }
        ///Create right wall
        for (int k = 0; k < ySize; k++)
        {
            if (doorRight - 1 == k)
            {
                Door = Instantiate(Door, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Door.transform.parent = WallParent.transform;
            }
            else if (windowRight)
            {
                Window = Instantiate(Window, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Window.transform.parent = WallParent.transform;
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Wall.transform.parent = WallParent.transform;
            }
        }

        ///Create left wall
        for (int p = 0; p < ySize; p++)
        {
            if (doorRight - 1 == p)
            {
                Door = Instantiate(Door, new Vector3(-FloorSize, FloorNr * WallHeight, p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Door.transform.parent = WallParent.transform;
            }
            else if (windowRight)
            {
                Window = Instantiate(Window, new Vector3(-FloorSize, FloorNr * WallHeight, p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Window.transform.parent = WallParent.transform;
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(-FloorSize, FloorNr * WallHeight, p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
                Wall.transform.parent = WallParent.transform;
            }
        }

        ///Create Objects in Room
        foreach (GameObject obj in RoomObject)
        {
            Instantiate(obj, ObjectLocations[index], ObjectRotation[index]);
            index++;
            obj.transform.parent = WallParent.transform.parent;
        }
    }
    public void Awake()
    {
        CreateFloor();
        CreateWalls();
    }
}
