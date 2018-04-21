using UnityEngine;
namespace TransformEffector
{
	[System.Serializable]
	public class EffectTarget
	{
		public Transform TR;
		public float ScaleWeight    = 1f;
		public float RotationWeight = 1f;
		public float PositionWeight = 1f;

		[System.NonSerialized]
		public Vector3 OrgLocPos;

		[System.NonSerialized]
		public Quaternion OrgRot;

		[System.NonSerialized]
		public Vector3 OrgLocScale;

		[System.NonSerialized]
		public float KeepScaleLength;

		[System.NonSerialized]
		public Quaternion DiffHandleRot;

		[System.NonSerialized]
		public Vector3 CorrectScaleRatio;
	}
}