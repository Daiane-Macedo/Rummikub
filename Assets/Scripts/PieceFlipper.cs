using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFlipper : MonoBehaviour
{
   SpriteRenderer spriteRenderer;
   PieceModel pieceModel;

   public AnimationCurve scaleCurve;
   public float duration = 0.5f; 

   void Awake()
   {
   		spriteRenderer = GetComponent<SpriteRenderer>();
   		pieceModel = GetComponent<PieceModel>();
   }

   public void FlipPiece(Sprite startImage, Sprite endImage, int pieceIndex)
   {
   		StopCoroutine(Flip(startImage, endImage, pieceIndex));
   		StartCoroutine(Flip(startImage, endImage, pieceIndex));
   }

   IEnumerator Flip(Sprite startImage, Sprite endImage, int pieceIndex)
   {
   		spriteRenderer.sprite = startImage;

   		float time = 0f;
   		while (time<=1f)
   		{
   			float scale = scaleCurve.Evaluate(time);
   			time = time + Time.deltaTime / duration;

   			Vector3 localScale = transform.localScale;
   			localScale.x = scale;
   			transform.localScale = localScale;

   			if(time >= 0.5)
   			{
   				spriteRenderer.sprite = endImage;
   			}
   			yield return new WaitForFixedUpdate();
   		}

   		if(pieceIndex == -1)
   		{
   			pieceModel.ToggleFace(false);
   		}
   		else
   		{
   			pieceModel.pieceIndex = pieceIndex;
   			pieceModel.ToggleFace(true);
   		}
   }
}
