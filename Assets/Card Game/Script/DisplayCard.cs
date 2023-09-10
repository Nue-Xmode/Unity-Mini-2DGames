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
        public Image cardBack;
        public Text costText;
        public Text atkText;
        public TextMeshProUGUI descriptionText;

        private void Update()
        {
            ShowCard();
            TurnUp();
        }

        /// <summary>
        /// 根据数据显示卡牌内容
        /// </summary>
        private void ShowCard()
        {
            Card temp = CardDatabase.I.GetCardInfo(displayId);
            
            nameText.text = temp.name;
            costText.text = temp.cost.ToString();
            atkText.text = temp.atk.ToString();
            descriptionText.text = temp.description;

            cardImage.sprite = CardDatabase.I.GetCardSprite(displayId);
        }

        /// <summary>
        /// 翻牌
        /// </summary>
        public void TurnUp()
        {
            if (Input.GetKeyDown(KeyCode.T))
                cardBack.enabled = !cardBack.enabled;
        }
    }
}