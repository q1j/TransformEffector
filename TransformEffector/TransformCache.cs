using UnityEngine;

public class TransformCache : MonoBehaviour
{
	[System.NonSerialized]
	public Transform TR;

	private void Awake()
	{
		TR = transform;
	}
}
