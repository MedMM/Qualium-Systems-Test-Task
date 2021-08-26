using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Wind : MonoBehaviour
{
	[SerializeField] private float force = 0.4f;
	[SerializeField] private Vector3 rotation;
	[SerializeField] private float rotationSpeed = 1f;
	private List<Rigidbody> _localRigidbodies;

	private void Update()
	{
		transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
		foreach (var rb in _localRigidbodies)
		{
			rb.AddForce(transform.forward.normalized * force);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		var rb = other.gameObject.GetComponent<Rigidbody>();
		if (rb != null)
		{
			_localRigidbodies.Add(rb);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		var rb = other.gameObject.GetComponent<Rigidbody>();
		if (rb != null)
		{
			_localRigidbodies.Remove(rb);
		}
	}
}