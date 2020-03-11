/*
  Author      高橋泰斗
  LastUpdate  2020/03/11
  Since       2020/03/11
  Contents    Cameraに関するScript。
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GetPieceCamera
{
    interface ICamera
    {
        vector3 GetCameraPosition(void);
        vector4 GetCameraAngle(void);
        void ActivateCamera(bool OnFlg);
    }

    abstract class CameraBase
    {
        private vector3 GetCameraPosition;
        private vector4 GetCameraAngle;
        private bool isActivateCamera;
    }


    class SetUpCamera : MonoBehaviour, ICamera
    {

    }

    class PlayCamera : MonoBehaviour, ICamera
    {

    }
}
