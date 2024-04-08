using UnityEngine;

namespace _Project.Runtime.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(CameraUtilities.GetCamWorldBoundingBox());
        }

    }
}
