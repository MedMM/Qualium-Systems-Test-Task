using Ui;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Vector3 ballStartPosition;
	[SerializeField] private Ball ball;
	[SerializeField] private GameCanvasView gameCanvasView;

	private void Start()
	{
		ball.OnBallFall += GameOverState;
		
		gameCanvasView.GameOverCanvas.restartButton
			.OnClickAsObservable()
			.Subscribe(_ => RestartGame());

		gameCanvasView.StartGameCanvas.startGameButton
			.OnClickAsObservable()
			.Subscribe(_ => RestartGame());
		
		gameCanvasView.GameOverCanvas.exitButton
			.OnClickAsObservable()
			.Subscribe(_ => Application.Quit());
	}

	private void GameOverState()
	{
		gameCanvasView.GameOverCanvas.gameObject.SetActive(true);
		gameCanvasView.InGameCanvas.Timer.StopTimer();
	}

	private void RestartGame()
	{
		gameCanvasView.GameOverCanvas.gameObject.SetActive(false);
		gameCanvasView.StartGameCanvas.gameObject.SetActive(false);
		gameCanvasView.InGameCanvas.gameObject.SetActive(true);
		
		gameCanvasView.InGameCanvas.Timer.RestartTimer();
		ball.Rigidbody.isKinematic = false;
		ball.transform.position = ballStartPosition;
		ball.Rigidbody.velocity = Vector2.zero;
	}
}