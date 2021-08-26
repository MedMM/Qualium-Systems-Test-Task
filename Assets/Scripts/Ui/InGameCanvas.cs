using UnityEngine;

namespace Ui
{
	public class InGameCanvas : MonoBehaviour
	{
		[SerializeField] private UiTextTimer timer;
		public UiTextTimer Timer => timer;
	}
}
