using System;
using UnityEngine;

namespace MiniGames.CardGame
{
    [Serializable]
    public class Card
    {
        public int id;
        public string name;
        public int cost;
        public int atk;
        [TextArea] public string description;

        public Card(int id, string name, int cost, int atk, string description)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.atk = atk;
            this.description = description;
        }
    }
}