using UnityEngine;

namespace TransformEffector
{
	public class EffectorHandle : TransformCache
	{
		public float WeightMax = 1f;
		public float WeightMin = 0.03f;

		public float XAngleLimit = 15f;
		public float YAngleLimit = 15f;
		public float ZAngleLimit = 15f;

		protected void OnValidate()
		{
			WeightMax = Mathf.Clamp(WeightMax, 0f, 1f);
			WeightMin = Mathf.Clamp(WeightMin, 0f, 1f);
			XAngleLimit = Mathf.Clamp(XAngleLimit, 0f, 180f);
			YAngleLimit = Mathf.Clamp(YAngleLimit, 0f, 180f);
			ZAngleLimit = Mathf.Clamp(ZAngleLimit, 0f, 180f);
		}

		protected Quaternion LimitedRotation(Quaternion arrivalRot)
		{
			Vector3 angles  = arrivalRot.eulerAngles;
			Vector3 limited = angles;
			limited.x = LimitedAngle(angles.x, XAngleLimit);
			limited.y = LimitedAngle(angles.y, YAngleLimit);
			limited.z = LimitedAngle(angles.z, ZAngleLimit);
			arrivalRot.eulerAngles = limited;
			return arrivalRot;
		}

		protected float LimitedAngle(float angle, float limit)
		{
			if (limit >= AbsoluteAngle(angle)) return angle;
			return (angle < 180f) ? limit : (360f - limit);
		}

		protected float AbsoluteAngle(float angle)
		{
			return (180f - Mathf.Abs((180f - angle) % 360f));
		}
	}
}
