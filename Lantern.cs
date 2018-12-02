using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {

    [SerializeField] private float battery;
    [SerializeField] private KeyCode LanternCode;
    [SerializeField] private float BatteryUsage;
    [SerializeField] private GameObject PlayerBody;
    [SerializeField] private GameObject LampBody;
    [SerializeField] private Transform balanceTarget;
    [SerializeField] private float RotationSpeed;

    private float RunningTime;
    private Quaternion lookRotation;
    private Vector3 direction;

    private bool balanced;

    private bool hasLantern;

    public void Awake()
    {
        this.hasLantern = false;
        BatteryUsage = 0.0f;
        LampBody.SetActive(false);
        PlayerBody.SetActive(false);
        balanced = false;
        //PlayerBody.SetActive(false);
    }

    private void useLantern()
    {
        if(Input.GetKeyDown(LanternCode))
        {
            if(hasLantern)
            {
                hasLantern = false;
                LampBody.SetActive(false);
                PlayerBody.SetActive(false);
            }
            else if(!hasLantern)
            {
                hasLantern = true;
                LampBody.SetActive(true);
                PlayerBody.SetActive(true);
            }
        }
        battery -= BatteryUsage;
    }

    private void balanceBody()
    {
        direction = (balanceTarget.position - LampBody.transform.position);

        lookRotation = Quaternion.LookRotation(direction);

        LampBody.transform.rotation = Quaternion.Slerp(transform.rotation,
            lookRotation, Time.deltaTime * RotationSpeed);

        ///LampBody.transform.position = balanceTarget.position;
        /// de lucrat la setat pozitia lampii la rotatie ///
        /// simulate de fizici ///
    }

    /*
     private void Float()
     ///Ramane de testat
    {
        Vector3 NewLocation = PlayerBody.transform.localPosition;

        float DeltaHeight = (Mathf.Sin(RunningTime + Time.deltaTime) - Mathf.Sin(RunningTime));

        NewLocation.z = DeltaHeight * 1.0f;
        RunningTime += Time.deltaTime;

        PlayerBody.transform.Translate(NewLocation);
    }
    */

    public void Update()
    {
        useLantern();
        balanceBody();
    }
}
