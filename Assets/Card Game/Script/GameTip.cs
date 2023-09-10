using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGames.CardGame
{
    public class GameTip : MonoBehaviour
    {
        private void OnGUI()
        {
            GUIStyle newStyle = new GUIStyle();
            newStyle.fontSize = 24;
            newStyle.normal.textColor = Color.red;
            
            GUI.Label(new Rect(10, 10, 200, 100), "按下T翻牌", newStyle);

        }
    }
}