using UnityEngine;

namespace _Project.Runtime.Scripts.UtilityComponents
{
    public class SetInactiveOutOfCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _goToSetInactive;
        
        private void OnBecameInvisible()
        {
            _goToSetInactive.SetActive(false);
        }
    }
}
