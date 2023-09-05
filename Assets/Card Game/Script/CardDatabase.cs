using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.CardGame
{
    public class CardDatabase : MonoBehaviour
    {
        public static List<Card> CardList = new List<Card>();

        private void Awake()
        {
            CardList.Add(new Card(0, "Human", 1, 1, "普通的人类"));
            CardList.Add(new Card(1, "Dragon", 7, 5, "普通的龙"));
            CardList.Add(new Card(2, "Elf", 3, 2, "普通的精灵"));
        }
    }
}