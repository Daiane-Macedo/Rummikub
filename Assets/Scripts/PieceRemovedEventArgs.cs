using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PieceRemovedEventArgs : EventArgs
{
    public int PieceIndex { get; private set; }
    
    public PieceRemovedEventArgs (int pieceIndex)
    {
        PieceIndex = pieceIndex;
    }
}