using System.Collections.Generic;
using UnityEngine;
using Utilitiees;

namespace MiniGames.CardGame
{
    public class CardDatabase : Singleton<CardDatabase>
    {
        public static List<Card> CardList = new List<Card>();
        public List<Sprite> spriteList = new List<Sprite>();

        public override void Awake()
        {
            base.Awake();
            CardList.Add(new Card(0, "Human", 1, 1, "a human"));
            CardList.Add(new Card(1, "Dragon", 7, 5, "a dragon"));
            CardList.Add(new Card(2, "Elf", 3, 2, "a elf"));
        }
        
        /// <summary>
        /// 获取特定卡牌的图片
        /// </summary>
        /// <returns></returns>
        public Sprite GetCardSprite(int displayId)
        {
            if (displayId < CardList.Count)
                return spriteList.Find(s => s.name == CardList[displayId].name);

            return null;
        }
    }
}