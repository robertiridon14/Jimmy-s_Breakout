using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour {

    [SerializeField] private int xSize;
    [SerializeField] private int ySize;

    [SerializeField] private int doorFront;
    [SerializeField] private int doorBack;
    [SerializeField] private int doorLeft;
    [SerializeField] private int doorRight;

    [SerializeField] private bool windowFront;
    [SerializeField] private bool windowBack;
    [SerializeField] private bool windowLeft;
    [SerializeField] private bool windowRight;

    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject Window;
    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Floor;

    [SerializeField] private float FloorSize;
    [SerializeField] private float WallHeight;
    [SerializeField] private float StairOpenX;
    [SerializeField] private float StairOpenY;
    [SerializeField] private int FloorNr;

    private GameObject newFloor;
    private Vector3 NewPosition;

    protected void CreateRoom()
    {
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
                }
            }
        }
        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(0.0f, 0.0f, 0.0f));

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
                }
            }
        }
        newFloor = Instantiate(Floor, NewPosition, Quaternion.Euler(180.0f, 0.0f, 0.0f));



        ///Create front wall
        for (int i = 0; i < xSize; i++)
        {
            if (i == doorFront - 1)
            {
                Door = Instantiate(Door, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            else if (windowFront)
            {
                Window = Instantiate(Window, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(i * WallHeight, 0.0f, WallHeight * FloorNr),
                    Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
        }
        ///Create Back wall
        for (int j = 0; j < xSize; j++)
        {
            if (doorBack - 1 == j)
            {
                Door = Instantiate(Door, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            else if (windowBack)
            {
                Window = Instantiate(Window, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(WallHeight * j, FloorNr * WallHeight, ySize * WallHeight),
                Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
        }
        ///Create right wall
        for (int k = 0; k < ySize; k++)
        {
            if (doorRight - 1 == k)
            {
                Door = Instantiate(Door, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
            else if (windowRight)
            {
                Window = Instantiate(Window, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(xSize * WallHeight - FloorSize, FloorNr * WallHeight, k * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
        }

        ///Create left wall
        for (int p = 0; p < ySize; p++)
        {
            if (doorRight - 1 == p)
            {
                Door = Instantiate(Door, new Vector3(-FloorSize , FloorNr * WallHeight,p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
            else if (windowRight)
            {
                Window = Instantiate(Window, new Vector3(-FloorSize, FloorNr * WallHeight, p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
            else
            {
                Wall = Instantiate(Wall, new Vector3(-FloorSize, FloorNr * WallHeight, p * WallHeight),
                Quaternion.Euler(0.0f, 90.0f, 0.0f));
            }
        }
    }
        public void Awake()
        {
            CreateRoom();
        }
    }
