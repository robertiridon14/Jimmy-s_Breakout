using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorEntity : MonoBehaviour {


    [SerializeField] private Vector3 Epsilon;
    private struct ArieInteres
    {
        float North;
        float South;
        float West;
        float East;
    }


    private Vector3 getPlayerPosition()
    {
        return transform.localPosition;
    }

    // Update is called once per frame
    void Update () {

        Debug.Log(getPlayerPosition());
    }
}
