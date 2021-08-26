using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformRotationController : MonoBehaviour
{
	[SerializeField, HideInInspector] private Rigidbody rb;
	[SerializeField] private float rotationMultiplier;
	private Vector2 _inputVector;
	
	
	private void Update()
	{
		_inputVector.x = SimpleInput.GetAxis("Horizontal");
		_inputVector.y = SimpleInput.GetAxis("Vertical");
		Vector3 rotationVector = new Vector3(_inputVector.y, 0, _inputVector.x * -1);
		SetRotation(rotationVector * rotationMultiplier);
	}

	private void SetRotation(Vector3 rotation) 
		=> rb.MoveRotation(Quaternion.Euler(rotation));

	private void OnValidate()
	{
		if (rb == null)
			rb = GetComponent<Rigidbody>();
	}
}