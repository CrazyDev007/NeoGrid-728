using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ToggleView : MonoBehaviour
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