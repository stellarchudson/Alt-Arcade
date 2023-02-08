using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;




public class Paddle : MonoBehaviour
{

    public Rigidbody2D rb;
    public int forceAdd = 20;
    public SerialPort stream = new SerialPort("/dev/cu.usbmodem14301", 9600);
    int buttonState;

    void Start()
    {
        stream.ReadTimeout = 100;
        stream.Open();
        Debug.Log(System.IO.Ports.SerialPort.GetPortNames());
    }

   


    void Update()
    {
        if (stream.IsOpen)
        {
            try
            {

                string input = stream.ReadLine();
                buttonState = int.Parse(input);

                if (buttonState == 3)
                {
                    //transform.position += Vector3.down * Time.deltaTime * forceAdd;
                    rb.AddForce(Vector3.down * forceAdd);
                    
                }

                

                if (buttonState == 40)
                {
                    //transform.position += Vector3.up * Time.deltaTime * forceAdd;
                    rb.AddForce(Vector3.up * forceAdd);
                    
                }
                
            }
            catch (Exception e)
            { //these hands

                //Debug.Log(e);
                return;
            }
        }
        

        

       
     
    }


   





}
