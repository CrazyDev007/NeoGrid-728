using System;
using Game.Presentation;
using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Infrastructure
{
    public class ToggleView : MonoBehaviour, IToggleView
    {
        [SerializeField] private GameMode mode;
        private Toggle _toggle;

        public GameMode GameMode => mode;
        public bool IsOn => _toggle.isOn;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        public void SetToggleAction(Action action)
        {
            _toggle.onValueChanged.AddListener(isOn => action());
        }
    }
}