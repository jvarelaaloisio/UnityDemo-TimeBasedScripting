using System.Collections;
using UnityEngine;

namespace Coroutines
{
    public class AnimateSphere : MonoBehaviour
    {
        [SerializeField] private AnimationCurve travelCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField] private float cooldown = 1;
        [SerializeField] private Transform sphere;
        [SerializeField] private Transform from;
        [SerializeField] private Transform to;

        private void OnEnable()
        {
            StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            var travelDuration = travelCurve.keys[^1].time;
            while (true)
            {
                var travelTime = 0.0f;
                while (travelTime < travelDuration)
                {
                    travelTime += Time.deltaTime;
                    var t = travelCurve.Evaluate(travelTime / travelDuration);
                    sphere.position = Vector3.Lerp(from.position, to.position, t);
                    yield return null;
                }

                sphere.position = to.position;
                (from, to) = (to, from);
                yield return new WaitForSeconds(cooldown);
            }
        }
    }
}