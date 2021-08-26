using UnityEngine;

namespace Ui
{
	public class GameCanvasView : MonoBehaviour
	{
		[SerializeField] private StartGameCanvas startGameCanvas;
		[SerializeField] private InGameCanvas inGameCanvas;
		[SerializeField] private GameOverCanvas gameOverCanvas;

		public StartGameCanvas StartGameCanvas => startGameCanvas;
		public InGameCanvas InGameCanvas => inGameCanvas;
		public GameOverCanvas GameOverCanvas => gameOverCanvas;
	}
}