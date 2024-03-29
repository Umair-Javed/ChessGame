﻿using WebFront.Enums;

namespace WebFront.Models
{
    public class PlayerModel
    {
        public string? Name { get; set; }
        public PlayerType Type { get; set; }
        public bool IsMyTurn { get; set; }
        public bool IsCoinExposed { get; set; }
        public string? UserIcon { get; set; }
    }
}
