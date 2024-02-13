using System;

public class Game
{
    public Game()
    {
        for (int i = 0; i < _board.Length; i++)
        {
            _board[i] = State.Unset;
        }
    }

    public int MovesCounter { get; internal set; }

    public readonly State[] _board = new State[9];

    public void MakeMove(int index)
    {
        if (index < 1 || index > 9)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (GetState(index) != State.Unset)
        {
            throw new InvalidOperationException();
        }

        _board[index - 1] = MovesCounter % 2 == 0 ? State.Cross : State.Circle;

        MovesCounter++;
    }

    public State GetState(int index)
    {
        return _board[index - 1];
    }

    public Winner GetWinner()
    {
        return GetWinner(1, 4, 7,
                         2, 5, 8, 
                         3, 6, 9,
                         1, 2, 3, 
                         4, 5, 6, 
                         7, 8, 9,
                         1, 5, 9,
                         3, 5, 7);
    }


    private Winner GetWinner(params int[] indexes)
    {
        for (int i = 0; i < indexes.Length; i+=3)
        {
            bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
            if (same)
            {
                State state = GetState(indexes[i]);
                if (state != State.Unset)
                {
                    return state == State.Cross ? Winner.Crosses : Winner.Circles;
                }
            }
        }

        if (MovesCounter < 9)
            return Winner.GameIsUnfinished;

        return Winner.Draw;
    }

    private bool AreSame(int v1, int v2, int v3)
    {
        return GetState(v1) == GetState(v2) && GetState(v1) == GetState(v3);
    }
}
