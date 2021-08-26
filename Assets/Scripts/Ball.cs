using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float fallDistance;
	public event Action OnBallFall;
	public Rigidbody Rigidbody => rb;

	void Update()
	{
		if (transform.position.y <= fallDistance) 
			OnBallFall?.Invoke();
	}
}