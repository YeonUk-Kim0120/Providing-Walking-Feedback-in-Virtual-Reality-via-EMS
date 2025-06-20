using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.IO.Ports;
using System;

public class LSerialObject : MonoBehaviour
{
    public static LSerialObject LInstance;
    public string portName = "COM11";
    public int baudRate = 9600;
    public SerialPort serialPort;

    void Awake()
    {
        if (LInstance == null)
        {
            LInstance = this;
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
