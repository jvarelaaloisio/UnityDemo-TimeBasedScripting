using UnityEngine;

namespace UpdateMethod
{
    public class AnimateSphere : MonoBehaviour
    {
        private enum State
        {
            Traveling,
            CoolingDown,
        }

        [SerializeField] private AnimationCurve travelCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        [SerializeField] private float cooldown = 1;
        [SerializeField] private Transform sphere;
        [SerializeField] private Transform from;
        [SerializeField] private Transform to;

        private float _travelTime = 0;
        private float _cooldownTime = 0;
        private State _state = State.Traveling;
        private void Update()
        {
            var travelDuration = travelCurve.keys[^1].time;
            switch (_state)
            {
                case State.Traveling:
                    _travelTime += Time.deltaTime;
                    if (_travelTime < travelDuration)
                    {
                        var t = travelCurve.Evaluate(_travelTime / travelDuration);
                        sphere.position = Vector3.Lerp(from.position, to.position, t);
                        break;
                    }

                    sphere.position = to.position;
                    (from, to) = (to, from);
                    _state = State.CoolingDown;
                    return;
                case State.CoolingDown:
                    _cooldownTime += Time.deltaTime;
                    if (_cooldownTime >= cooldown)
                    {
                        _cooldownTime = 0;
                        _travelTime = 0;
                        _state = State.Traveling;
                    }
                    break;
            }
        }
    }
}