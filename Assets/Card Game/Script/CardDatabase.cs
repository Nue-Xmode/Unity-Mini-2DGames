using System.Collections.Generic;
using UnityEngine;
using Utilitiees;

namespace MiniGames.CardGame
{
    public class CardDatabase : Singleton<CardDatabase>
    {
        private static List<Card> _mCardList = new List<Card>();
        [SerializeField] private List<Sprite> spriteList = new List<Sprite>();
        public static int CardCount => _mCardList.Count;

        [SerializeField] private PlayerDeck mPlayerDeck;
        public override void Awake()
        {
            base.Awake();
            _mCardList.Add(new Card(0, "Human", 1, 1, "a human"));
            _mCardList.Add(new Card(1, "Dragon", 7, 5, "a dragon"));
            _mCardList.Add(new Card(2, "Elf", 3, 2, "a elf"));
            _mCardList.Add(new Card(3, "Demon", 10, 12, "a demon"));
        }
        
        /// <summary>
        /// 获取特定卡牌的图片
        /// </summary>
        /// <returns></returns>
        public Sprite GetCardSprite(int displayId)
        {
            if (displayId < _mCardList.Count)
                return spriteList.Find(s => s.name == _mCardList[displayId].name);

            return null;
        }

        /// <summary>
        /// 获取特定卡牌信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card GetCardInfo(int index)
        {
            return _mCardList[index];
        }
        
        /// <summary>
        /// 获取特定卡牌数据的副本
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card CreateCard(int index)
        {
            return _mCardList[index].Copy();
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        public void Shuffle()
        {
            //手牌
            if (_mCardList != null)
            {
                for (int i = 0; i < CardCount; i++)
                {
                    int targetIndex = Random.Range(0, CardCount);

                    if (targetIndex != i)
                    {
                        //交换
                        Card temp = _mCardList[i].Copy();
                        _mCardList[i].SetCard(_mCardList[targetIndex]);
                        _mCardList[targetIndex].SetCard(temp);
                    }
                }
            }
            
            //牌堆
            if (mPlayerDeck != null)
            {
                for (int i = 0; i < mPlayerDeck.deck.Count; i++)
                {
                    int targetIndex = Random.Range(0, CardCount);

                    if (targetIndex != i)
                    {
                        //交换
                        Card temp = mPlayerDeck.deck[i].Copy();
                        mPlayerDeck.deck[i].SetCard(mPlayerDeck.deck[targetIndex]);
                        mPlayerDeck.deck[targetIndex].SetCard(temp);
                    }
                }
            }
        }
    }
}