﻿using Assets.Scripts.Extra;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TimerController : MonoBehaviour, IVisible, IUiControl
    {
        public bool Freeze;
        public GameObject Text;

        private CanvasGroup _canvasGroup;
        private float _alpha = 0.0f;
        private Text _text;

        private void Awake()
        {
            this._text = Text.GetComponent<Text>();
            this._canvasGroup = GetComponentInParent<CanvasGroup>();
        }

        private void Update()
        {
            CheckVisibilityChanges();
            UpdateTime();
        }

        private void UpdateTime()
        {
            if (!this.Freeze)
            {
                var timeLeft = Global.CurrentRoundTime;
                this._text.text = timeLeft.ToString();
            }
        }

        public bool CheckVisibilityChanges()
        {
            if (Mathf.Abs(_canvasGroup.alpha - _alpha) > 0.0001)
            {
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, _alpha, 0.1f);
                return true;
            }
            return false;
        }

        public void IsVisible(bool visible)
        {
            _alpha = visible ? 1.0f : 0.0f;
        }
    }
}
