using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DirectorAI;
namespace DirectorAI
{
    public class DirectorEntity : MonoBehaviour
    {
        [SerializeField] private Vector3 Epsilon;
        [SerializeField] private float Omega;

        public float North;
        public float South;
        public float West;
        public float East;
        public float Up;
        public float Down;

        private void Awake()
        {
            Omega = 25.0f;
            Epsilon.x = Omega;
            Epsilon.z = Omega;
            Epsilon.y = Omega;
        }

        private void getPlayerPosition()
        {
            North = transform.position.x + Epsilon.x;
            Debug.Log("nord " + North);
            South = transform.position.x - Epsilon.x;
            Debug.Log("sud " + South);
            East = transform.position.z + Epsilon.z;
            Debug.Log("est " + East);
            West = transform.position.z - Epsilon.z;
            Debug.Log("vest " + West);
            Up = transform.position.y + Epsilon.y;
            Debug.Log("up " + Up);
            Down = transform.position.y - Epsilon.y;
            Debug.Log("Down " + Down);
        }
    }
}
