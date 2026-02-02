using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions 
{
	
	public class BoostAT : ActionTask
	{
		public BBParameter<float> currentScanRadiusBB;
		public float boostValue = 5f;

		protected override void OnExecute() 
		{
			currentScanRadiusBB.value += boostValue;

			EndAction(true);
		}

		
	}
}