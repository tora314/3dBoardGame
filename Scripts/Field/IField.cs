using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Field
{

interface IField 
{
    Vector3 GetPositionFromId(int id);

    void WriteFieldInfo(int pieceId,int faceId);

    void DeleteFieldInfo(int pieceId);

    int ReadFieldInfo(int pieceId);

    List<int> GetAdjacentSurface(int crrId , Vector3 FowardDirection);

    void PointMovableFace(List<int> facesId, List<bool> movableFace);
}

}

