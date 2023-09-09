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

        public Card () {}
        public Card(int id, string name, int cost, int atk, string description)
        {
            this.id = id;
            this.name = name;
            this.cost = cost;
            this.atk = atk;
            this.description = description;
        }

        /// <summary>
        /// 获取卡牌数据的副本
        /// </summary>
        /// <returns></returns>
        public Card Copy()
        {
            Card newCard = new Card()
            {
                id = this.id,
                name = this.name,
                cost = this.cost,
                atk = this.atk,
                description = this.description
            };

            return newCard;
        }
    }
}