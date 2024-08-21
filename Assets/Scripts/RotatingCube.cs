using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{

    public Vector3 RotateAxis = new Vector3(1, 1, 1);

    public Vector3 StartPos = new Vector3(1, 1 , 0);

    // Vector3(X, Y, Z)
    // X =  right (positive) Vector3(1, 0, 0) Vector3.right
    //      left (negative) Vector3(-1, 0, 0) Vector3.left
    // Y =  up (positive) Vector3(0, 1, 0) Vector3.up
    //      down (negative) Vector3(0, -1, 0) Vector3.down
    // Z =  forward (positive) Vector3(0, 0, 1) Vector3.forward
    //      backward (negative) Vector3(0, 0, -1) Vector3.back
    // Vector3.one = Vector3(1, 1, 1)
    
    public float rotationSpeed = 50f;
    public float movementSpeed = 2f;

    public int frameCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
    }

    // Update is called once per frame
    // e.g. for 20fps, Update() is executed 20 times in 1 second
    void Update()
    {
        frameCount += 1;
        // Rotate
        // Time.deltaTime is the time in between frames (e.g. time between frame1 and frame2)
        // using Time.deltaTime makes the movement frame independent - same speed no matter what the fps
        // Time.deltaTime roughly equal to 1 / fps e.g. 1/20 (0.05) is the time for each frame with 20 fps

        transform.Rotate(RotateAxis * Time.deltaTime * rotationSpeed);

        // Increase rotation speed after each frame
        // rotationSpeed += 1f;

        // or
        // Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, RotateAxis);
        // transform.rotation = rotation * transform.rotation;


        // Move
        // Vector3.forward is shorthand for new Vector3(0, 0, 1)
        // Space.Self - move the object in the local axis not the world axis
        //
        // For 20 fps -> Update is called 20 times per second
        // total movement = 20 * Vector3.forward * speed * Time.deltaTime
        // Time.deltaTime will be 1/20 = 0.05
        // total movement = 20 * 1 * 10 * 0.05 = 10
        //
        // For 500 fps -> Update called 500 times per second
        // Time.deltaTime will be 1/500 = 0.002
        // total movement = 500 * 1 * 10 * 0.002 = 10
        // Total movement for 20 fps and 500 fps will remain the same

        
        float x = StartPos[0];
        float y = StartPos[1];
        float z = StartPos[2];

        // Change movement direction (left or right) every 20 frames
        if (frameCount % 20 == 0) {
            StartPos.Set(-x, -y, z);
        }


        transform.Translate(StartPos * movementSpeed * Time.deltaTime);

        // transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.Self);
        
    }



}
