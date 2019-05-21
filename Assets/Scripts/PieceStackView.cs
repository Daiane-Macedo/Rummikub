using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PieceStack))]
public class PieceStackView : MonoBehaviour
{
    PieceStack deck;
    Dictionary<int, GameObject> fetchedPieces;
    int lastCount;

    public Vector3 start;
    public float pieceOffset;
    public GameObject piecePrefab;
    public bool faceUp;

    void Start() 
    {
        fetchedPieces = new Dictionary<int, GameObject>();
        deck = GetComponent<PieceStack>();
        ShowPieces();
        lastCount = deck.PieceCount;

        deck.PieceRemoved += deck_PieceRemoved;

    }

    void deck_PieceRemoved (object sender, PieceRemovedEventArgs e)
    {
        if (fetchedPieces.ContainsKey(e.PieceIndex))
        {
            Destroy(fetchedPieces[e.PieceIndex]);
            fetchedPieces.Remove(e.PieceIndex);
        }
    }

    void Update()
    {
        if (lastCount != deck.PieceCount)
        {
            lastCount = deck.PieceCount;
            ShowPieces();
        }
    }

    void ShowPieces() 
    {
        int pieceCount = 0;

        if (deck.HasPieces)
        {
            foreach (int i in deck.GetPieces())
            {
                float po = pieceOffset * pieceCount;
                Vector3 temp = start + new Vector3(po,0f);
                AddPiece(temp, i, pieceCount);
                pieceCount++; 
            }

        }
    }

    void AddPiece(Vector3 position, int pieceIndex, int positionalIndex) 
    {
        if (fetchedPieces.ContainsKey(pieceIndex))
        {
            return;
        }

        GameObject pieceCopy = Instantiate(piecePrefab) as GameObject;
        pieceCopy.transform.position = position;
                
        PieceModel pieceModel = pieceCopy.GetComponent<PieceModel>();
        pieceModel.pieceIndex = pieceIndex;
        pieceModel.ToggleFace(faceUp);
        
         switch (pieceIndex/26)
        {
            case (0):
                pieceModel.color = "Red";
                break;
            case (1):
                pieceModel.color = "Black";
                break;
            case (2):
                pieceModel.color = "Green";
                break;
            case (3):
                pieceModel.color = "Yellow";
                break;
            default:
                pieceModel.color = "Joker";
                break;
        }
        if (pieceModel.color == "Joker")
        {
            pieceModel.value = 20;
        }
        else
        {
            pieceModel.value = ((pieceIndex/2)%13)+1;
            if (pieceModel.value == 0)
            {
                pieceModel.value = 13;
            }
        }
        
            
        SpriteRenderer spriteRenderer = pieceCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionalIndex;

        fetchedPieces.Add(pieceIndex, pieceCopy);
    }
}
