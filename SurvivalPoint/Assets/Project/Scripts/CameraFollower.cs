using UnityEngine;

namespace FastPlatform.Environment
{
    [RequireComponent(typeof(Camera))]
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;

        private void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }
        
            Vector3 position = _target.position;
            transform.position = new Vector3
            {
                x = position.x + _offset.x,
                y = position.y + _offset.y,
                z = position.z + _offset.z,
            };
        }
    }
}