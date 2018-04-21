namespace TransformEffector
{
	public interface ITransformEffect
	{
		void Prepare();
		void UpdatePropertys();
		void Operate(EffectTarget target);
		void InitTarget(EffectTarget target);
	}
}
