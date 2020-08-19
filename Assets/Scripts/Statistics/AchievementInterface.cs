﻿using ColorGradients;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace Statistics {
    public class AchievementInterface : MonoBehaviour
    {
        //Reference Variables
        private Achievement thisAchievement = null;

        //State Variables
        private TextMeshProUGUI achievementName = null;
        private TextMeshProUGUI description = null;
        private TextMeshProUGUI coinReward = null;
        private Image checkSprite = null;
        private Image coinSprite = null;

        //Internal Methods
        private void FindInterfaceFields() {
            Transform interfaceTransform = gameObject.transform;
            achievementName = interfaceTransform.Find("Name").GetComponent<TextMeshProUGUI>();
            description = interfaceTransform.Find("Description").GetComponent<TextMeshProUGUI>();
            coinReward = interfaceTransform.Find("CoinAmount").GetComponent<TextMeshProUGUI>();
            checkSprite = interfaceTransform.Find("CheckSprite").GetComponent<Image>();
            coinSprite = interfaceTransform.Find("CoinSprite").GetComponent<Image>();
        }
        
        private void SetParameters(bool completed) {
            achievementName.text = thisAchievement.name;
            description.text = thisAchievement.description;
            if (completed) {
                achievementName.GetComponent<UIColorChanger>().enabled = true;
                coinReward.gameObject.SetActive(false);
                coinSprite.gameObject.SetActive(false);
                checkSprite.gameObject.SetActive(true);
            } else {
                achievementName.GetComponent<UIColorChanger>().enabled = false;
                coinReward.text = thisAchievement.coinReward.ToString();
                coinSprite.gameObject.SetActive(true);
                checkSprite.gameObject.SetActive(false);
            }
        }

        //Public Methods
        public void SetInterfaceObjectParameters(Achievement achievement, bool completed) {
            thisAchievement = achievement;
            FindInterfaceFields();
            SetParameters(completed);
        }
    }
}
