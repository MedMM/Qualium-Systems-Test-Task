using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
	public class UiTextTimer : MonoBehaviour
	{
		[SerializeField] private Text timerText;
		private bool _isTimerOn = true;
		private float _currentTime;
		private float CurrentTime
		{
			get => _currentTime;
			set
			{
				_currentTime = value;
				DisplayTime(_currentTime);
			}
		}

		public void RestartTimer()
		{
			CurrentTime = default;
			StartTimer();
		}

		public void StartTimer()
			=> _isTimerOn = true;

		public void StopTimer()
			=> _isTimerOn = false;

		private void Update()
		{
			if (_isTimerOn)
			{
				CurrentTime += Time.deltaTime;
			}
		}

		private void DisplayTime(float timeToDisplay)
		{
			float minutes = Mathf.FloorToInt(timeToDisplay / 60);
			float seconds = Mathf.FloorToInt(timeToDisplay % 60);
			float milliSeconds = (timeToDisplay % 1) * 100;
			milliSeconds = Mathf.Round(milliSeconds);

			timerText.text = $"{minutes:00}:{seconds:00}:{milliSeconds:00}";
		}
	}
}