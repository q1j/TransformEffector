namespace TransformEffector
{
	class ScaleRecoil : TransformCache, IHandleRecoil
	{
		public float Weight   = 0.3f;
		public float Friction = 0.3f;

		private Vec3RecoilTool tool_;

		void Start()
		{
			tool_ = new Vec3RecoilTool(TR.localScale);
		}

		public void UpdateToRecoil()
		{
			if (0f == Weight || 0f == Friction) return;
			TR.localScale = tool_.Recoil(TR.localScale, Weight, Friction);
		}
	}
}
