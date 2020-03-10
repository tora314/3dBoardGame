/*
  Author      藤澤典隆
  LastUpdate  2020/03/10
  Since       2020/03/10
  Contents    駒のprafabが持つScript。

  namespaceが現在グローバルなので注意。

  注意:カメラオブジェクトを子要素として持たせておく。
  　　さらに子カメラのaudioListnerを取り去り、offにしておく必要がある。

   Field.Pieceは
        void Move(Vector3 ToPosition);
        void Rotate(Vector3 rotate);
    を継承しており、利用可能。
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldPiece : Piece.Pieces
{
    public void testfunc()
    {
        Debug.Log("アクセス成功！！");
        Move(new Vector3(0.5f, 0, 0));
        Rotate(new Vector3(45f, 45f, 45f));
    }

}
