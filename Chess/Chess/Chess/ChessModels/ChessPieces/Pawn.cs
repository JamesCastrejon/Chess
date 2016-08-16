﻿using System;
using System.Collections.Generic;

namespace Chess.ChessModels
{
    public class Pawn : ChessPiece
    {
        private int _moves;
        public Pawn()
        {
            Init();
        }

        public Pawn(ChessColor color)
        {
            Color = color;
            Init();
        }

        private void Init()
        {
            Name = "Pawn";
            Symbol = 'P';
            ResetMovement();
            _moves = 0;
        }
        public override void MovePiece(ChessSquare[,] board, int startX, int startY, int endX, int endY)
        {
            board[endX, endY].Piece = board[startX, startY].Piece;
            board[startX, startY].Piece = new Space();
        }
        public override bool CheckMovement(ChessSquare[,] board, int startX, int startY, int endX, int endY)
        {
            ResetMovement();
            bool isValid = false;
            List<int[]> available = RestrictMovement(board, startX, startY);
            for (int x = 0; x < available.Count; ++x)
            {
                if (available[x][0] == endX && available[x][1] == endY)
                {
                    isValid = true;
                    ++_moves;
                }
            }
            return isValid;
        }
        public override List<int[]> RestrictMovement(ChessSquare[,] board, int startX, int startY)
        {
            List<int[]> available = new List<int[]>();
            bool isAvailable = false;
            if (Color == ChessColor.DARK)
            {
                if (startX + 1 < 8)//down 1
                {
                    isAvailable = IsEmpty(board, startX + 1, startY, 0);
                    if (isAvailable == true)
                    {
                        if (canMove[0] == true)
                        {
                            available.Add(new int[] { startX + 1, startY });
                        }
                    }
                }
                if (_moves == 0)//down 2
                {
                    isAvailable = IsEmpty(board, startX + 2, startY, 6);
                    if (isAvailable == true)
                    {
                        if (canMove[0] == true)
                        {
                            available.Add(new int[] { startX + 2, startY });
                        }
                    }
                }
                if (startX + 1 < 8 && startY - 1 >= 0)//down Left 1
                {
                    if (board[startX + 1, startY - 1].Piece.Color != Color && board[startX + 1, startY - 1].Piece.Color != ChessColor.NONE)
                    {
                        isAvailable = IsAvailable(board, startX + 1, startY - 1, 1);
                        if (isAvailable == true)
                        {
                            if (canMove[1] == true)
                            {
                                available.Add(new int[] { startX + 1, startY - 1 });
                            }
                        }
                    }
                }
                if (startX + 1 < 8 && startY + 1 < 8)//down right 1
                {
                    if (board[startX + 1, startY + 1].Piece.Color != Color && board[startX + 1, startY + 1].Piece.Color != ChessColor.NONE)
                    {
                        isAvailable = IsAvailable(board, startX + 1, startY + 1, 2);
                        if (isAvailable == true)
                        {
                            if (canMove[2] == true)
                            {
                                available.Add(new int[] { startX + 1, startY + 1 });
                            }
                        }
                    }
                }
            }
            else
            {
                if (startX - 1 >= 0)//up 1
                {
                    isAvailable = IsEmpty(board, startX - 1, startY, 3);
                    if (isAvailable == true)
                    {
                        if (canMove[3] == true)
                        {
                            available.Add(new int[] { startX - 1, startY });
                        }
                    }
                }
                if (_moves == 0)//up 2
                {
                    isAvailable = IsEmpty(board, startX - 2, startY, 7);
                    if (isAvailable == true)
                    {
                        if (canMove[3] == true)
                        {
                            available.Add(new int[] { startX - 2, startY });
                        }
                    }
                }
                if (startX - 1 >= 0 && startY - 1 >= 0)//up left 1
                {
                    if (board[startX - 1, startY - 1].Piece.Color != Color && board[startX - 1, startY - 1].Piece.Color != ChessColor.NONE)
                    {
                        isAvailable = IsAvailable(board, startX - 1, startY - 1, 4);
                        if (isAvailable == true)
                        {
                            if (canMove[4] == true)
                            {
                                available.Add(new int[] { startX - 1, startY - 1 });
                            }
                        }
                    }
                }
                if (startX - 1 >= 0 && startY + 1 < 8)//up right 1
                {
                    if (board[startX - 1, startY + 1].Piece.Color != Color && board[startX - 1, startY + 1].Piece.Color != ChessColor.NONE)
                    {
                        isAvailable = IsAvailable(board, startX - 1, startY + 1, 5);
                        if (isAvailable == true)
                        {
                            if (canMove[5] == true)
                            {
                                available.Add(new int[] { startX - 1, startY + 1 });
                            }
                        }
                    }
                }
            }
            return available;
        }
        public override bool IsAvailable(ChessSquare[,] board, int row, int column, int index)
        {
            bool canMove = true;
            if (board[row, column].Piece.Color == Color && board[row, column].Piece.Color != ChessColor.NONE)
            {
                canMove = false;
            }
            if (this.canMove[index] == true)
            {
                this.canMove[index] = canMove;
            }
            return canMove;
        }
        public bool IsEmpty(ChessSquare[,] board, int row, int column, int index)
        {
            bool canMove = true;
            if (board[row, column].Piece.Color != ChessColor.NONE)
            {
                canMove = false;
            }
            if (this.canMove[index] == true)
            {
                this.canMove[index] = canMove;
            }
            return canMove;
        }
        public override void ResetMovement()
        {
            canMove = new bool[] { true, true, true, true, true, true, true, true};
        }
        public override List<int[]> Test(ChessSquare[,] board, int startX, int startY, int endX, int endY)
        {
            bool isMoveSet = false;
            List<int[]> available = new List<int[]>();
                if (startX + 1 < 8)//down
                {
                    available.Add(new int[] { startX + 1, startY });
                    if (startX + 1 == endX && startY == endY)
                    {
                        isMoveSet = true;
                    }
                }
            Test2(available, isMoveSet);
            if (isMoveSet == false)
            {
                if (startX + 1 < 8 && startY - 1 >= 0)//down Left
                {
                    available.Add(new int[] { startX + 1, startY - 1 });
                    if (startX + 1 == endX && startY - 1 == endY)
                    {
                        isMoveSet = true;
                    }
                }
                Test2(available, isMoveSet);
            }
            if (isMoveSet == false)
            {
                if (startX + 1 < 8 && startY + 1 < 8)//down right
                {
                    available.Add(new int[] { startX + 1, startY + 1 });
                    if (startX + 1 == endX && startY + 1 == endY)
                    {
                        isMoveSet = true;
                    }
                }
                Test2(available, isMoveSet);
            }
            if (isMoveSet == false)
            {
                    if (startX - 1 >= 0)//up
                    {
                        available.Add(new int[] { startX - 1, startY });
                        if (startX - 1 == endX && startY == endY)
                        {
                            isMoveSet = true;
                        }
                    }
                Test2(available, isMoveSet);
            }
            if (isMoveSet == false)
            {
                    if (startX - 1 >= 0 && startY - 1 >= 0)//up left
                    {
                        available.Add(new int[] { startX - 1, startY - 1 });
                        if (startX - 1 == endX && startY - 1 == endY)
                        {
                            isMoveSet = true;
                        }
                    }
                Test2(available, isMoveSet);
            }
            if (isMoveSet == false)
            {
                    if (startX - 1 >= 0 && startY + 1 < 8)//up right
                    {
                        available.Add(new int[] { startX - 1, startY + 1 });
                        if (startX - 1 == endX && startY + 1 == endY)
                        {
                            isMoveSet = true;
                        }
                    }
                Test2(available, isMoveSet);
            }
            return available;
        }

        public override void Test2(List<int[]> available, bool isMoveSet)
        {
            if (isMoveSet == false)
            {
                available.Clear();
            }
        }
        /****************************/
    }
}
