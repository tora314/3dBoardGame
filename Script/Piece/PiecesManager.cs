/*
  Author      藤澤典隆
  LastUpdate  2020/03/10
  Since       2020/03/10
  Contents    Pieceに関するScript。適当な空のオブジェクトにアタッチする。
*/

/*駒の追加する場合:
 抽象クラスPieceInfoを継承したクラスを作成し、PieceManagerのawakeに追加する*/

/*重複した要素を持つリストを返すことがあるので受取手はforeach使うよりfor推奨 https://ja.ojit.com/so/c%23/858084*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Piece
{
    interface IPiecesManager
    {
        Pieces GetPieceById(int pieceId);
        float GetSummonCost(String pieceKind);
        void GeneratePiece(String pieceKind, int absoluteFaceId);
        Dictionary<int, List<bool>> GetMoveRange(string pieceKind);
    }


    class PiecesManager : MonoBehaviour, IPiecesManager
    {

        private int PieceNum = 0;
        Dictionary<string, PieceInfo> AllPieceInfo = new Dictionary<string, PieceInfo>();
        Dictionary<int, Pieces> AllPieces = new Dictionary<int, Pieces>();

        void Awake()
        {
            AllPieceInfo = new Dictionary<string, PieceInfo>()
            {
                { "King"  , new King()  },
                { "Queen" , new Queen() },
            };
        }

        //初期の角度をどうするのか。
        public void GeneratePiece(string pieceKind, int absoluteFaceId)
        {

            GameObject obj = AllPieceInfo[pieceKind].Prefab;
            //追加::
            //fieldnamespaceの面の絶対IDから座標を受け取る関数            //Instantiate(obj, position, Quaternion.Identity);
            GameObject ins = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            var temp = ins.GetComponent<FieldPiece>();
            AllPieces.Add(PieceNum, temp);
            ins.GetComponent<FieldPiece>().Init(PieceNum, pieceKind);
            PieceNum += 1;
        }

        public float GetSummonCost(string pieceKind)
        {
            return AllPieceInfo[pieceKind].Cost;
        }

        public Pieces GetPieceById(int pieceId)
        {
            return AllPieces[pieceId];
        }

        public Dictionary<int, List<bool>> GetMoveRange(string pieceKind)
        {
            return AllPieceInfo[pieceKind].MoveRange;
        }

    }





    abstract class PieceInfo
    {
        public string Name { get; set; }
        public float Cost { get; set; }
        public GameObject Prefab { get; set; }
        public Dictionary<int, List<bool>> MoveRange { get; set; }
    }

    class King : PieceInfo
    {
        public King()
        {
            Name = "King";
            Cost = 3030;
            Prefab = (GameObject)Resources.Load(Name);
            MoveRange = new Dictionary<int, List<bool>>()
            {
                { 4 , new List<bool>() { false, true, false, true } },
                { 6 , new List<bool>() { true,  true, true , true} },
                { 10, new List<bool>() { true,  true, true,  true } },
            };
        }

    }

    class Queen : PieceInfo
    {
        public Queen()
        {
            Name = "Queen";
            Cost = 330;
            Prefab = (GameObject)Resources.Load(Name);
            MoveRange = new Dictionary<int, List<bool>>()
            {
                { 4 , new List<bool>() { false, true, false, true } },
                { 6 , new List<bool>() { true,  true, true , true} },
                { 10, new List<bool>() { true,  true, true,  true } },
            };
        }

    }




    abstract public class Pieces : MonoBehaviour, IPiece
    {
        //追加::配置されている駒が実際に移動できる範囲の取得
        //Fiele.FieleInfo GetMoveRange(int Id)

        private int Id = 100;
        private string Name = null;

        public void Init(int pieceId, string kindName)
        {
            Id = pieceId;
            Name = kindName;
        }

        public void Move(Vector3 ToPosition)
        {
            transform.Translate(ToPosition);
        }

        public void Rotate(Vector3 rotate)
        {
            transform.Rotate(rotate);
        }
    }

    interface IPiece
    {
        void Init(int pieceId, string kindName);
        void Move(Vector3 ToPosition);
        void Rotate(Vector3 rotate);
    }



}
