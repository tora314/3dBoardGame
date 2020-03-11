/*
  Author      小路重虎
  LastUpdate  2020/03/11
  Since       2020/03/11
  Contents    プレイヤー情報に関するスクリプト
*/

namespace Player
{
  interface IPlayer
  {
    List<GameObject> GetMyPieces(void);
    Dictionary<string,float> GetPlayerId(void);
    void SetMyPieces(List<GameObject> golist);
  }

  abstract class PlayerBase : IPlayer
  {
    List<GameObject> MyPieces;
    int PlayerId;
  }

  class Player : PlayerBase
  {

  }

  class NPC : PlayerBase
  {

  }
}
