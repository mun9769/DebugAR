using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour
{
    // Gyro
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rotation;

    // Cam
    private WebCamTexture cam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool arReady = false;

    private void Start()
    {
        #region CheckPossible
        // Check if we support both services
        // Gyroscope
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("this device does not have gyroscope");
            return;
        }
        // Back Camera
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if(!WebCamTexture.devices[i].isFrontFacing)
            {
                cam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        // if we did not find a back camera, exit
        if(cam == null)
        {
            Debug.Log("this device does not have back camera");
            return;
        }
        #endregion


        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;
        cameraContainer.transform.rotation = Quaternion.Euler(90f, 0, 0);
        rotation = new Quaternion(0, 0, 1, 0);

        cam.Play();
        background.texture = cam;

        arReady = true;

    }

    private void Update()
    {
        if(arReady)
        {
            // update camera
            float ratio = (float)cam.width / (float)cam.height;
            fit.aspectRatio = ratio;

            float scaleY = cam.videoVerticallyMirrored ? -1.0f : 1.0f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -cam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
            // update gyro
            transform.localRotation = gyro.attitude * rotation;
        }
    }
}
