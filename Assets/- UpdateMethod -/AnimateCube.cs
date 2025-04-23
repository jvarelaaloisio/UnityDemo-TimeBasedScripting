using UnityEngine;

namespace UpdateMethod
{
    public class AnimateCube : MonoBehaviour
    {
        [SerializeField] private Transform cube;

        private void Reset() => cube = transform;
        private void Update()
        {
            var t = Time.time;
            cube.Rotate(new Vector3(Mathf.Cos(t), Mathf.Sin(t), Mathf.Cos(t)), Space.World);
        }
    }
}