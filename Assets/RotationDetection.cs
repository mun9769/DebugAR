using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDetection : MonoBehaviour
{
    Gyroscope _gyro;
    public GameObject arSession;
    public GameObject arCamera;
    private void Start()
    {
        _gyro = Input.gyro;
        _gyro.enabled = true;
        Debug.Log(Quaternion.Euler(90.0f, 0.0f, 0.0f));
    }
    public void Btn_CheckAttribute()
    {
        ScreenLog.Log("attitude                 " + _gyro.attitude);
        ScreenLog.Log(".ToEulerAngles(attitude)" + Quaternion.ToEulerAngles(_gyro.attitude));
        ScreenLog.Log("attitude.eulerAngle    " + _gyro.attitude.eulerAngles);
        ScreenLog.Log("Angle(arCamera, attitude)    " + Quaternion.Angle(arCamera.transform.rotation, _gyro.attitude));
        ScreenLog.Log("gravity                " + _gyro.gravity);
        ScreenLog.Log("arCamera.transform.position: " + arCamera.transform.position);
        ScreenLog.Log("arCamera.transform.rotation: " + arCamera.transform.rotation);
        ScreenLog.Log("--------------------------------------------------");
        // ScreenLog.Log("rotationRate        " + _gyro.rotationRate);
        // ScreenLog.Log("rotationRateUnbi " + _gyro.rotationRateUnbiased);
        // ScreenLog.Log("userAcceleration " + _gyro.userAcceleration);
        // ScreenLog.Log("updateInterval      " + _gyro.updateInterval);
    }

    public int[,] mat3x3 = new int[3, 3];


}
