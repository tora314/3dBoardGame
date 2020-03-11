using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class FieldManager : MonoBehaviour,IField
    {
        [SerializeField] private GameObject TestCube;

        private FieldInfo fieldInfo;
        private FieldPieceInfo fieldPieceInfo;

        void Start()
        {
            fieldInfo = GetComponent<FieldInfo>();
            fieldPieceInfo = GetComponent<FieldPieceInfo>();

            //Debug.Log(GetPositionFromId(1));


        }

        void Update()
        {
            GetAdjacentSurface(1, TestCube.transform.TransformDirection(TestCube.transform.forward));
        }



        public Vector3 GetPositionFromId(int id)
        {
            var info = fieldInfo.FieldInfoDictionary;
        
            return  info[id].FacePosition;
        }

        public void WriteFieldInfo(int pieceId, int faceId)
        {
            fieldPieceInfo.FieldPieceInfoDict[pieceId] = faceId; 
        }

        public void DeleteFieldInfo(int pieceId)
        {
            fieldPieceInfo.FieldPieceInfoDict.Remove(pieceId);
        }

        public int ReadFieldInfo(int pieceId)
        {
            int fieldId;

            fieldId = fieldPieceInfo.FieldPieceInfoDict[pieceId];

            return fieldId;
        }

        public List<int> GetAdjacentSurface(int crrId, Vector3 FowardDirection)
        {
            return fieldInfo.NeighborFace(crrId,FowardDirection);
        }

        public void PointMovableFace(List<int> facesId, List<bool> movableFace)
        {

        }
    }

}


