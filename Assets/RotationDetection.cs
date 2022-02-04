using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDetection : MonoBehaviour
{
    Gyroscope _gyro;
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
        ScreenLog.Log("Angle(attitude, attitude)    " + Quaternion.Angle(_gyro.attitude, _gyro.attitude));
        ScreenLog.Log("gravity                " + _gyro.gravity);
        ScreenLog.Log("--------------------------------------------------");
        // ScreenLog.Log("rotationRate        " + _gyro.rotationRate);
        // ScreenLog.Log("rotationRateUnbi " + _gyro.rotationRateUnbiased);
        // ScreenLog.Log("userAcceleration " + _gyro.userAcceleration);
        // ScreenLog.Log("updateInterval      " + _gyro.updateInterval);
    }
}
