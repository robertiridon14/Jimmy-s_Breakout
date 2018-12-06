using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITree : MonoBehaviour {

    public Transform moveSpots;
    public float speed;

    private float WaitTime;
    public float startWaitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

	void Awake()
    {
        startWaitTime = startWaitTime;
        moveSpots.position = new Vector3(Random.RandomRange(minX, maxX), Random.RandomRange(0, 5), Random.RandomRange(minY, maxY));
    }
	

	void Update () {
            transform.position = Vector3.MoveTowards(transform.position,moveSpots.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,moveSpots.position) < 0.2f)
        {
            if(WaitTime <= 0)
            {
                WaitTime = startWaitTime;
                moveSpots.position = new Vector3(Random.RandomRange(minX, maxX), Random.RandomRange(0, 5), Random.RandomRange(minY, maxY));
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }

    }
}
