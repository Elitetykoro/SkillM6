using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class JumpTime : MonoBehaviour
{
    enum State { isRunning, notRunning, hasBeenRunned}
    State myState;
    float timer = 0;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject brick;
    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;
    private void Start()
    {
        myState = State.notRunning;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && myState != State.hasBeenRunned)
        {
            myState = State.isRunning;
            acceleration = new Vector3(0,-4,0);
            velocity = new Vector3 (0,5,0);
        }
        if (myState == State.isRunning)
        {
            timer += Time.deltaTime;
            velocity += acceleration * Time.deltaTime;
            brick.transform.position += velocity * Time.deltaTime;
            if(brick.transform.position.y <= -3.25f) myState = State.hasBeenRunned;
        }
        timerText.text = System.Math.Round(timer,2).ToString();


    }
}
