using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Field
{
    public class SurfaceInfo : MonoBehaviour
    {
        [SerializeField] private int pieceId = 0;

        [SerializeField] private int sideNum = 0;

        [SerializeField] GameObject Arrow ;

        Color[] color = { Color.red, Color.blue, Color.green, Color.black };
    
      // MeshFilter meshFilter= GetComponent<MeshFilter>();


            public int PieceId
        {
            get{
                return pieceId;
            }

            set
            {
                pieceId = value;
            }
        }

        public int SideNum
        {
            get
            {
                return sideNum;
            }

     
        }

        public  Vector3 FacePosition
        {
            get
            {
                return this.transform.position;
            }
        }

        public List<int> GetFaces(Vector3 pieceDirection)
        {
                var neaberFaces = new List<int>();
                var from2Angle = Vector3.SignedAngle(transform.TransformDirection(transform.forward),pieceDirection, transform.TransformDirection(transform.up));
                if(from2Angle<0)
                {
                    from2Angle = Mathf.Abs(from2Angle) + 180;
                }
                Debug.Log((int)(from2Angle / (360 / sideNum)));
                var directionIndex = ComplementIndex((int)(from2Angle/(360 / sideNum)));

                RaycastHit hit;
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                for (int i = 0; i < sideNum; i++)
                {
                    var rayDirection = transform.rotation * transform.TransformDirection(transform.forward);
                    Quaternion axisAngle = Quaternion.AngleAxis(directionIndex[i] * 360 / sideNum, transform.up);

                    rayDirection = axisAngle * rayDirection;

                    Ray ray = new Ray(transform.position, rayDirection);

                    if (Physics.Raycast(ray, out hit, 10.0f))
                    {
                        //Debug.Log(hit.collider.gameObject.name);
                        neaberFaces.Add(hit.collider.gameObject.GetComponent<SurfaceInfo>().PieceId);
                    }

                    Debug.DrawRay(ray.origin, ray.direction * 10, color[i], 5);
                }

                return new List<int>();
        }

        private List<int> ComplementIndex(int startIndex)
            {
                List<int> l= new List<int>();
                for (int i = 0; i <= sideNum; i++)
                {
                    if (startIndex + i < sideNum)
                    {
                       l.Add(startIndex+i);
                    }
                    else
                    {
                        l.Add(sideNum-startIndex-i);
                    }
                
                }

                return l;
            }

        public void ActivateArrow(bool isActivate) {
                Arrow.GetComponent<Renderer>().enabled = isActivate ;
            }

        void Update()
        {
                //GetFaces(transform.position);

            }
    }



}




