using UnityEngine;

namespace Game.Bootstrap
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        private void Awake()
        {
            InstallBindings();
        }

        protected abstract void InstallBindings();
    }
}