using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;



public class debugInfoScript : MonoBehaviour
{
    public int avgFrameRate;
    int memoryUsage;
    int cpuUsage;

    [Header("UI Text objects")]
    public Text Device_Model;
    public Text Device_OS;
    public Text Device_Name;
    public Text CPU_Model;
    public Text CPU_CoreCount;
    public Text GPU_Model;
    public Text GPU_VRAM;
    public Text System_Memory_Total;


    public Text FPS_Text;

    //variables to hold system info
    string _deviceModel;
    string _deviceOS;
    string _deviceName;
    string _CPUModel;
    int _CPUCoreCount;
    string _GPUModel;
    int _GPUVRAM;
    int _deviceMemoryTotal;

    float _currentFPS;

    // Start is called before the first frame update
    void Start()
    {
        //get system information
        _deviceModel = SystemInfo.deviceModel;
        _deviceOS = SystemInfo.operatingSystem;
        _deviceName = SystemInfo.deviceName;
        _CPUModel = SystemInfo.processorType;
        _CPUCoreCount = SystemInfo.processorCount;
        _GPUModel = SystemInfo.graphicsDeviceName;
        _GPUVRAM = SystemInfo.graphicsMemorySize;
        _deviceMemoryTotal = SystemInfo.systemMemorySize;


        //set 1 time variable values
        Device_Model.text = "Device Model: " + _deviceModel;
        Device_OS.text = "OS: " + _deviceOS;
        Device_Name.text = "Device Name: " + _deviceName;
        CPU_Model.text = "CPU Type: " + _CPUModel;
        CPU_CoreCount.text = "CPU Threads: " + _CPUCoreCount;
        GPU_Model.text = "GPU Moldel: " + _GPUModel;
        GPU_VRAM.text = "GPU VRAM Total: " + _GPUVRAM + "MB";
        System_Memory_Total.text = "SysMem Total: " + _deviceMemoryTotal + "MB";

    }


    public void Update()
    {
        _currentFPS = 0;
        _currentFPS = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)_currentFPS;
        FPS_Text.text = avgFrameRate.ToString() + " FPS";   
    }
}
