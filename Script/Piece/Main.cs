///*
//  Author      藤澤典隆
//  LastUpdate  2020/03/10
//  Since       2020/03/10
//  Contents    PiecesManagerとPieceのテスト。そのうち削除
//*/

//using UnityEngine;

//public class Main : MonoBehaviour
//{
//    public GameObject gameobject;
//    void Start()
//    {
//        Piece.PiecesManager PM = gameobject.GetComponent<Piece.PiecesManager>();
//        Debug.Log(PM.GetSummonCost("King"));
//        PM.GeneratePiece("King", 1);
//        GameObject a = PM.GetPieceObjById(0);
//        if (a != null)
//        {
//            a.GetComponent<FieldPiece>().testfunc();
//            a.GetComponent<FieldPiece>().Move(new Vector3(1f, 1f, 1f));
//            a.GetComponent<FieldPiece>().Rotate(new Vector3(1f, 1f, 1f));
//        }
//        PM.GeneratePiece("King", 1);
//    }
//}
