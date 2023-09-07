using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.CardGame
{
    public class DisplayCard : MonoBehaviour
    {
        public int diaplayId;

        public Text nameText;
        public Text costText;
        public Text atkText;
        public TextMeshProUGUI descriptionText;

        private void Update()
        {
            ShowCard();
        }

        /// <summary>
        /// 根据数据显示卡牌内容
        /// </summary>
        private void ShowCard()
        {
            nameText.text = CardDatabase.CardList[diaplayId].name;
            costText.text = CardDatabase.CardList[diaplayId].cost.ToString();
            atkText.text = CardDatabase.CardList[diaplayId].atk.ToString();
            descriptionText.text = CardDatabase.CardList[diaplayId].description;
        }
    }
}