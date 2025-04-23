using TMPro;
using UnityEngine;

namespace UpdateMethod
{
    public class AnimateText : MonoBehaviour
    {
        private const string SizePrefix = "<size={0}%>";
        private const string SizeSuffix = "</size>";
        [SerializeField] private TMP_Text label;
        [SerializeField] private short maxScale = 125;
        [SerializeField] private float minScale = 100;
        [SerializeField] private short speed = 200;
        private string _originalText;
        private float _previousCharScale;
        private float _currentCharScale;
        private short _currentChar;
        
        private void Reset() => label = GetComponent<TMP_Text>();
        
        private void Awake()
        {
            _originalText = label.text;
            _previousCharScale = minScale;
            _currentCharScale = minScale;
        }

        private void Update()
        {
            var sizeDelta = Time.deltaTime * speed;
            _currentCharScale += sizeDelta;
            _previousCharScale -= sizeDelta;
            
            if (_previousCharScale <= minScale)
            {
                if (++_currentChar > _originalText.Length)
                    _currentChar = 0;
                _previousCharScale = maxScale;
                _currentCharScale = minScale;
            }

            var previousCharIndex = Mathf.Max(0, _currentChar - 1);
            var currentCharIndex = Mathf.Min(_originalText.Length - 1, _currentChar);
            
            var previousChar = _currentChar <= 0
                                   ? string.Empty
                                   : GetSizePrefix(_previousCharScale) + _originalText[previousCharIndex] + SizeSuffix;
            
            var currentChar = _currentChar >= _originalText.Length
                                  ? string.Empty
                                  :GetSizePrefix(_currentCharScale) + _originalText[currentCharIndex] + SizeSuffix;
            
            var prefix = _originalText[..previousCharIndex];
            var suffix = _originalText[(currentCharIndex + 1)..];
            label.text = $"{prefix}{previousChar}{currentChar}{suffix}";
        }

        private static string GetSizePrefix(float scale)
            => string.Format(SizePrefix, Mathf.Floor(scale));
    }
}