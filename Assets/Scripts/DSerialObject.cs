using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using System;

public class DSerialObject : MonoBehaviour
{
    public static DSerialObject DInstance;
    public string portName = "COM13";
    public int baudRate = 9600;
    public SerialPort serialPort;

    void Awake()
    {
        if (DInstance == null)
        {
            DInstance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSerialPort();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeSerialPort()
    {
        serialPort = new SerialPort(portName, baudRate);
        try
        {
            serialPort.Open();
            Debug.Log("Serial port opened");
        }
        catch (IOException e)
        {
            Debug.LogError("IOException: " + e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogError("UnauthorizedAccessException: " + e.Message);
        }
    }
    
    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial port closed");
        }
    }

    public void SendData(string data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                serialPort.Write(data);
                Debug.Log(data);
            }
            catch (IOException e)
            {
                Debug.LogError("IOException when writing to port: " + e.Message);
            }
        }
    }
}
