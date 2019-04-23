using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceModel : MonoBehaviour
{
	SpriteRenderer spriteRenderer;

    public Sprite[] faces;
    public Sprite pieceBack;


    public int pieceIndex;
	public int value;
	public string color;

    public void ToggleFace(bool showFace)
    {
    	if (showFace)
    	{
    		spriteRenderer.sprite = faces[pieceIndex];
    	}
    	else
    	{
    		spriteRenderer.sprite = pieceBack;
    	}
    }


    void Awake()
    {
    	spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
