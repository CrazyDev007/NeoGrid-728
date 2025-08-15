using UnityEngine;
using UnityEngine.InputSystem;

namespace Components
{
    public class ClickDetector2D : MonoBehaviour
    {
        private Camera _mainCamera;
        private InputAction _clickAction;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _clickAction = new InputAction(binding: "<Mouse>/leftButton");
            _clickAction.performed += delegate
            {
                var mousePosition = Mouse.current.position.ReadValue();
                var ray = _mainCamera!.ScreenPointToRay(mousePosition);
                var hit = Physics2D.GetRayIntersection(ray);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    SendMessage("OnMouseClicked2D");
                }
            };
            _clickAction.Enable();
        }

        private void OnDestroy()
        {
            _clickAction.Disable();
        }
    }
}