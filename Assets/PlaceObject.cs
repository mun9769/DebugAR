using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    public GameObject testObject;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    static public PlaceObject instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ScreenLog.Log("PlaceObject Start");
        Input.gyro.enabled = true;
    }
    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        TEST(touchPosition);
    }

    private void TEST(Vector2 touchPosition)
    {
        if(raycaster.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            ARRaycastHit arHit = hits[0];
            Pose hitPose = hits[0].pose;
            GameObject tmp = Instantiate(testObject, hitPose.position, hitPose.rotation);
            ScreenLog.Log("arHit.pose.position : " + hitPose.position);
//            ScreenLog.Log("arHit.pose.rotation : " + arHit.pose.rotation);
//            ScreenLog.Log("arHit.distance : " + arHit.distance);
//            ScreenLog.Log("arHit.sessionRelativePose.position : " + arHit.sessionRelativePose.position);
//            ScreenLog.Log("arHit.sessionRelativePose.rotation : " + arHit.sessionRelativePose.rotation);
//            ScreenLog.Log("arHit.sessionRelativedistance : " + arHit.sessionRelativeDistance);
//            ScreenLog.Log("--------------------------------------------------------------------------");
            Destroy(tmp, 3.0f);
        }
    }
    public void PositionCalculate()
    {
        Vector3 vectorPhoneToPhone = ;
        float[,] rotMat = new float[3, 3];
        rotMat = QuaternionToRotationMatrix(Input.gyro.attitude);

        float[,] countMat = new float[3, 3];


    }
    public float[,] QuaternionToRotationMatrix(Quaternion Q)
    {
        float q0, q1, q2, q3;
        q0 = Q[0];
        q1 = Q[1];
        q2 = Q[2];
        q3 = Q[3];

        float r00, r01, r02, r10, r11, r12, r20, r21, r22;
        r00 = 2 * (q0 * q0 + q1 * q1) - 1;
        r01 = 2 * (q1 * q2 - q0 * q3);
        r02 = 2 * (q1 * q3 + q0 * q2);

        r10 = 2 * (q1 * q2 + q0 * q3);
        r11 = 2 * (q0 * q0 + q2 * q2) - 1;
        r12 = 2 * (q2 * q3 - q0 * q1);

        r20 = 2 * (q1 * q3 - q0 * q2);
        r21 = 2 * (q2 * q3 + q0 * q1);
        r22 = 2 * (q0 * q0 + q3 * q3) - 1;

        float[,] rot_matrix = new float[3, 3];

        rot_matrix[0,0] = r00;
        rot_matrix[0,1] = r01;
        rot_matrix[0,2] = r02;

        rot_matrix[1,0] = r10;
        rot_matrix[1,1] = r11;
        rot_matrix[1,2] = r12;
        
        rot_matrix[2,0] = r20;
        rot_matrix[2,1] = r21;
        rot_matrix[2,2] = r22;
        return rot_matrix;

    }
    public float[,] InverseMat3x3(float[,] mat)
    {
        float determinant = 0.0f;
        determinant = mat[0,0]*mat[1,1]*mat[2,2] - mat[0,0]*mat[1,2]*mat[2,1]
                    + mat[0,1]*mat[1,2]*mat[2,0] - mat[0,1]*mat[1,0]*mat[2,2]
                    + mat[0,2]*mat[1,0]*mat[2,1] - mat[0,2]*mat[1,1]*mat[2,0];
        if(determinant == 0.0f)
        {
            ScreenLog.Log("determinent is 0 , so\n inverse matrix no exist");
        }

        float[,] inv = new float[3, 3];

        for(int i=0;i<3;i+=1)
        { 
            for (int j = 0; j < 3; j += 1)
            {
                inv[i,j] = 1.0f / determinant *

                    (mat[(i + 1) % 3, (j + 1) % 3] * mat[(i + 2) % 3, (j + 2) % 3] 

                    - mat[(i + 1) % 3, (j + 2) % 3] * mat[(i + 2) % 3, (j + 1) % 3]);
            }
        }
        return inv;
    }
}
