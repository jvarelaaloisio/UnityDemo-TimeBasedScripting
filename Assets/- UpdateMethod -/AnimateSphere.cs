using System.Linq;
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

        private float _travelTimer = 0;
        private float _cooldownTimer = 0;
        private State state = State.Traveling;
        private void Update()
        {
            var travelDuration = travelCurve.keys.Last().time;
            switch (state)
            {
                case State.Traveling:
                    _travelTimer += Time.deltaTime;
                    if (_travelTimer < travelDuration)
                    {
                        sphere.position = Vector3.Lerp(from.position, to.position, travelCurve.Evaluate(_travelTimer / travelDuration));
                        break;
                    }

                    sphere.position = to.position;
                    (from, to) = (to, from);
                    state = State.CoolingDown;
                    return;
                case State.CoolingDown:
                    _cooldownTimer += Time.deltaTime;
                    if (_cooldownTimer >= cooldown)
                    {
                        _cooldownTimer = 0;
                        _travelTimer = 0;
                        state = State.Traveling;
                    }
                    break;
            }
        }
    }
}