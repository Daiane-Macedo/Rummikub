using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public PieceStack dealer;
    public PieceStack player;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,256,28), "Click"))
        {
            player.Draw(dealer);
        }
    }


}
