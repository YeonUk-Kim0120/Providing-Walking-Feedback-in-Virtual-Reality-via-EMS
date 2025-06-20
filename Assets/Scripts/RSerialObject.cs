using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using System;

public class RSerialObject : MonoBehaviour
{
    public static RSerialObject RInstance;
    public string portName = "COM9";
    public int baudRate = 9600;
    public SerialPort serialPort;

    void Awake()
    {
        if (RInstance == null)
        {
            RInstance = this;
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
    /*
    private void Start()
    {
        Instance = this;
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();

    }*/
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
