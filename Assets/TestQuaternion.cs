using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuaternion : MonoBehaviour
{
    private void Start()
    {
        // Debug.Log(Quaternion.ToEulerAngles(new Quaternion(1, 0, 0, 1)));
        // Debug.Log(Quaternion.Euler(new Vector3(60,0,0)));
        Quaternion a = new Quaternion(0.4f, 0.1f, 0.3f, 0.9f);
        Quaternion b = new Quaternion(0.1f, 0.0f, -0.6f, 0.8f);
        Debug.Log(Quaternion.Angle(a, b));
    }
}
