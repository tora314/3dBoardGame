using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
public class PieceCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        for(int i = 0; i < 4; i++)
        {
            var rayDirection = transform.rotation * transform.TransformDirection(transform.forward);
            Quaternion axisAngle = Quaternion.AngleAxis(i*360 / 4, -Vector3.up);

            rayDirection = axisAngle * rayDirection;

            Ray ray = new Ray(transform.position, rayDirection);
        
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                Debug.Log(hit.collider.gameObject);
            }
           
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
            }
        

        //return new List<int>();
    }
}



}

