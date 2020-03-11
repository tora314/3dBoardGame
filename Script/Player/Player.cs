/*
  Author      小路重虎
  LastUpdate  2020/03/11
  Since       2020/03/11
  Contents    プレイヤー情報に関するスクリプト
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    interface IPlayer
    {
        List<GameObject> GetMyPieces();
        Dictionary<string, float> GetPlayerId();
        void SetMyPieces(List<GameObject> golist);
    }

    abstract class PlayerBase : IPlayer
    {
        protected List<GameObject> MyPieces;//クラス図ではprivateとなっている
        protected int PlayerId;//クラス図ではprivateとなっている

        public List<GameObject> GetMyPieces()
        {
            return MyPieces;
        }

        public Dictionary<string, float> GetPlayerId()
        {
            return PlayerId;//エラー
        }

        public void SetMyPieces(List<GameObject> golist)
        {
            MyPieces.AddRange(golist);
        }
    }

    class Player : PlayerBase
    {
        public Player()
        {
            PlayerId = 0;
        }
    }

    class NPC : PlayerBase
    {
        public NPC()
        {
            PlayerId = 1;
        }
    }
}
