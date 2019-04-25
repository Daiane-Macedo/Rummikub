using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceStack : MonoBehaviour
{
    List<int> pieces;

    public bool isDealer;
    public bool isPlaying;
    public bool isAI;

    public List<PieceStack> players;

    public bool HasPieces
    {
        get { return pieces != null && pieces.Count > 0; }
    }

    public event PieceRemovedEventHandler PieceRemoved;

    public int PieceCount
    {
        get
        {
            if (pieces == null)
            {
                return 0;
            }
            else
            {
                return pieces.Count;
            }
        }
    }
    
    public IEnumerable<int> GetPieces() 
    {
        foreach (int i in pieces)
        {
            yield return i;
        }
    }

    public int Pop()
    {
        int temp = pieces[PieceCount - 1];
        pieces.RemoveAt(PieceCount - 1);

        if (PieceRemoved == null)
        {
            return temp;
        }
        PieceRemoved(this, new PieceRemovedEventArgs(temp));

        return temp;
    }

    public void Push(int piece) 
    {
        pieces.Add(piece);
    }

    public void Shuffle(List<int> deck, int n)
    {
        while (n > 1) 
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = pieces[k];
            pieces[k] = pieces[n];
            pieces[n] = temp;
        }
    }

    public void CreateDeck()
    {
        pieces.Clear();

        for (int i = 0; i < 104; i++)
        {
            pieces.Add(i);
        }

        //Shuffle(pieces, pieces.Count);
        
    }

    public void Draw(PieceStack dealer)
    {
        Push(dealer.Pop());
    }

    void Start ()
    {
        pieces = new List<int>();
        if (isDealer) 
        {
            CreateDeck();
            foreach (PieceStack player in players)
            {
                if (player.isPlaying)
                {
                    for (int i = 0; i < 14; i++)
                    {
                        player.Draw(this);
                    }

                }
            }
            pieces.Add(104);
            pieces.Add(105);
            //Shuffle(pieces, pieces.Count);
        }
    }
}
