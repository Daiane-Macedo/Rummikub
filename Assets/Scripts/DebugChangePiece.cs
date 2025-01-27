﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugChangePiece : MonoBehaviour
{
	PieceFlipper flipper;
	PieceModel pieceModel;
	int pieceIndex = 0;
	public GameObject piece;
    void Awake()
    {
    	pieceModel = piece.GetComponent<PieceModel>();
    	flipper = piece.GetComponent<PieceFlipper>();
    }

    void OnGUI()
    {
    	if (GUI.Button(new Rect(10, 10, 100, 28), "Click"))
    	{
    		if(pieceIndex >= pieceModel.faces.Length)
    		{
    			pieceIndex = 0;
    			flipper.FlipPiece(pieceModel.faces[pieceModel.faces.Length - 1], pieceModel.pieceBack, -1);
    		}
    		else
    		{
    			if(pieceIndex > 0)
    			{
    				flipper.FlipPiece(pieceModel.faces[pieceIndex - 1], pieceModel.faces[pieceIndex], pieceIndex);
    			}
    			else
    			{
    				flipper.FlipPiece(pieceModel.pieceBack, pieceModel.faces[pieceIndex], pieceIndex);
    			}
    			pieceIndex++;
    		}
    	}
    }
}