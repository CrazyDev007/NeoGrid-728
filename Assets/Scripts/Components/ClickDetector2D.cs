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

            // Create an input action for the left mouse button.
            _clickAction = new InputAction(binding: "<Mouse>/leftButton");

            // Define what happens when the action is performed.
            _clickAction.performed += ctx =>
            {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    SendMessage("OnMouseClicked2D", true);
                }
                else
                {
                    SendMessage("OnMouseClicked2D", false);
                }
            };

            _clickAction.Enable(); // Enable the action to start listening for input.
        }

        // Remember to disable the action when the object is destroyed.
        void OnDestroy()
        {
            _clickAction.Disable();
        }
    }
}