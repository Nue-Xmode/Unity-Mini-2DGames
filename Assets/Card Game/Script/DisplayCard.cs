using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.CardGame
{
    public class DisplayCard : MonoBehaviour
    {
        public int displayId;

        public Text nameText;
        public Image cardImage;
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
            nameText.text = CardDatabase.CardList[displayId].name;
            costText.text = CardDatabase.CardList[displayId].cost.ToString();
            atkText.text = CardDatabase.CardList[displayId].atk.ToString();
            descriptionText.text = CardDatabase.CardList[displayId].description;

            cardImage.sprite = CardDatabase.I.GetCardSprite(displayId);
        }
    }
}