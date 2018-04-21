using UnityEngine;
namespace TransformEffector
{
	public class Vec3RecoilTool
	{
		private Vector3 velocity_;
		private Vector3 orgVec_;

		public Vec3RecoilTool(Vector3 orgVec)
		{
			velocity_ = Vector3.zero;
			orgVec_   = orgVec;
		}

		public Vector3 Recoil(Vector3 target, float weight, float friction)
		{
			velocity_ += (orgVec_ - target) * weight;
			velocity_ *= friction;
			return (target + velocity_);
		}
	}
}