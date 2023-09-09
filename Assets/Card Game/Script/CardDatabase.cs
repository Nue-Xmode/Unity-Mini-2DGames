using System.Collections.Generic;
using UnityEngine;
using Utilitiees;

namespace MiniGames.CardGame
{
    public class CardDatabase : Singleton<CardDatabase>
    {
        private static List<Card> mCardList = new List<Card>();
        [SerializeField] private List<Sprite> spriteList = new List<Sprite>();

        public static int CardCount => mCardList.Count;
        public override void Awake()
        {
            base.Awake();
            mCardList.Add(new Card(0, "Human", 1, 1, "a human"));
            mCardList.Add(new Card(1, "Dragon", 7, 5, "a dragon"));
            mCardList.Add(new Card(2, "Elf", 3, 2, "a elf"));
            mCardList.Add(new Card(3, "Demon", 10, 12, "a demon"));
        }
        
        /// <summary>
        /// 获取特定卡牌的图片
        /// </summary>
        /// <returns></returns>
        public Sprite GetCardSprite(int displayId)
        {
            if (displayId < mCardList.Count)
                return spriteList.Find(s => s.name == mCardList[displayId].name);

            return null;
        }

        /// <summary>
        /// 获取特定卡牌信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card GetCardInfo(int index)
        {
            return mCardList[index];
        }
        
        /// <summary>
        /// 获取特定卡牌数据的副本
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card CreateCard(int index)
        {
            return mCardList[index].Copy();
        }
    }
}