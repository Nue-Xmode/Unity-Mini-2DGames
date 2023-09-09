using System.Collections;
using System.Collections.Generic;
using MiniGames.CardGame;
using UnityEngine;

namespace MiniGames
{
    public class PlayerDeck : MonoBehaviour
    {
        public List<Card> deck = new List<Card>(40);
        
        // Start is called before the first frame update
        void Start()
        {
            InitDeck();
        }

        // Update is called once per frame
        void Update()
        {

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
    }
}