using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class FieldInfo : MonoBehaviour
    {
        [SerializeField] private Transform FieldParent;

        private Transform[] FieldChildren;

        private Dictionary<int, SurfaceInfo> FieldInfoDict = new Dictionary<int, SurfaceInfo>();

        void Awake()
        {
            InisializeField();

        }


        public Dictionary<int, SurfaceInfo> FieldInfoDictionary
        {
        
            get
            {
                return FieldInfoDict;
            }
        }

        public List<int> NeighborFace(int faceId , Vector3 pieceDirection)
        {
            var surfaceInfo = FieldInfoDictionary[faceId];

            List<int> neghborFace = surfaceInfo.GetFaces(pieceDirection);

            return neghborFace;
        }

        
        public void ActivateArrows(List<int> facesId, List<bool> movableFace)
        {
            for(int i = 0; i < facesId.Count; i++)
            {
                FieldInfoDictionary[facesId[i]].ActivateArrow(movableFace[i]) ;
            }
        }


        private void InisializeField()
        {

            SurfaceInfo surFaceInfo;
            int pieceId = 0;
            Transform child;

            for (int i=0; i<FieldParent.childCount;i++)
            {
                child = FieldParent.GetChild(i);

                surFaceInfo = child.gameObject.GetComponent<SurfaceInfo>();
                //Debug.Log(child.gameObject.name);
                surFaceInfo.PieceId = pieceId;

                FieldInfoDict[pieceId] = surFaceInfo;

                pieceId += 1;
            }
        }


   
    }



}


