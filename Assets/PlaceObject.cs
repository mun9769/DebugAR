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
            ScreenLog.Log("arHit.pose.rotation : " + arHit.pose.rotation);
            ScreenLog.Log("arHit.distance : " + arHit.distance);
            ScreenLog.Log("arHit.sessionRelativePose.position : " + arHit.sessionRelativePose.position);
            ScreenLog.Log("arHit.sessionRelativePose.rotation : " + arHit.sessionRelativePose.rotation);
            ScreenLog.Log("arHit.sessionRelativedistance : " + arHit.sessionRelativeDistance);
            ScreenLog.Log("--------------------------------------------------------------------------");
            Destroy(tmp, 3.0f);
        }
    }
}
