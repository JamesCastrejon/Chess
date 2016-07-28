﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ChessModels
{
    public class Utility
    {
        #region Variables
        private string _piece;
        private string _color;
        private string _square;
        #endregion
        /// <summary>
        /// Checks character parameter if it represents a board piece.
        /// </summary>
        /// <param name="piece">
        /// K = King
        /// Q = Queen
        /// B = Bishop
        /// N = Knight
        /// R = Rook
        /// P = Pawn
        /// </param>
        /// <returns>Returns the name of a board piece</returns>
        public string CheckPiece(char piece)
        {
            if (piece == 'K' || piece == 'Q' || piece == 'B' || piece == 'N' || piece == 'R' || piece == 'P')
            {
                switch (piece)
                {
                    case 'K':
                        return "King";
                    case 'Q':
                        return "Queen";
                    case 'B':
                        return "Bishop";
                    case 'N':
                        return "Knight";
                    case 'R':
                        return "Rook";
                    case 'P':
                        return "Pawn";
                }
            }
            else
            {
                new Exception("Invalid character piece...");
            }
            return "";
        }
        /// <summary>
        /// Checks character parameter if represents a color.
        /// </summary>
        /// <param name="color">
        /// l = "Light"
        /// d = "Dark"
        /// </param>
        /// <returns>Returns dark or light</returns>
        public string CheckColor(char color)
        {
            if (color == 'l' || color == 'd')
            {
                switch (color)
                {
                    case 'l':
                        return "White";
                    case 'd':
                        return "Black";
                }
            }
            else
            {
                new Exception("Invalid color character...");
            }
            return "";
        }
        /// <summary>
        /// Places square in an incomplete sentence.
        /// </summary>
        /// <param name="square">Represents a square</param>
        /// <returns>returns a sentence regarding where the piece has been placed.</returns>
        public string PlacePiece(string square)
        {
            return ("has been moved to " + square + ".");
        }
        /// <summary>
        /// Sets the variables to the values passed in the parameters.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="color"></param>
        /// <param name="square"></param>
        public void StorePiece(char piece, char color, string square)
        {
            Piece = CheckPiece(piece);
            Color = CheckColor(color);
            Square = PlacePiece(square);
        }
        public string Piece { get {return _piece; } set {_piece = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public string Square { get { return _square; } set { _square = value; } }
        //-----------------------------------------------------------------------------------
    }
}
