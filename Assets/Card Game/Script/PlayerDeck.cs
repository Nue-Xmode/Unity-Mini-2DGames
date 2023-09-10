using System.Collections;
using System.Collections.Generic;
using MiniGames.CardGame;
using UnityEngine;

namespace MiniGames
{
    public class PlayerDeck : MonoBehaviour
    {
        public List<Card> deck = new List<Card>(40);

        [SerializeField] private DisplayCard firstCard;    //牌堆顶端的牌
        
        private void Start()
        {
            InitDeck();
        }
        
        void Update()
        {
            ShowFirstCardInDeck();
        }

        /// <summary>
        /// 初始化牌堆数据
        /// </summary>
        private void InitDeck()
        {
            for (int i = 0; i < 40; i++)
            {
                int index = Random.Range(0, CardDatabase.CardCount);
                deck[i] = CardDatabase.I.CreateCard(index);
            }
        }

        /// <summary>
        /// 显示牌堆顶端的牌
        /// </summary>
        private void ShowFirstCardInDeck()
        {
            int displayId = 0;
            if (deck != null && firstCard != null)
            {
                displayId = deck[0].id;
                firstCard.displayId = displayId;
            }
        }
    }
}