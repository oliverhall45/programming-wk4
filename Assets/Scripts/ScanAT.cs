using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions 
{

	public class ScanAT : ActionTask 
	{
		public BBParameter<Transform> targetBB;
		public BBParameter<bool> hasTargetBB;
		public BBParameter<float> initialScanRadiusBB;
		public BBParameter<float> currentScanRadiusBB;

		public LayerMask targetLayerMask;
		public float scanDurationInSeconds;
		public Color scanColour;
		public int numberOfScanCirclePoints;

		private float currentScanDuration = 0f;

		
		protected override string OnInit() 
		{
			currentScanRadiusBB.value = initialScanRadiusBB.value;
			return null;
		}

		
		protected override void OnExecute() 
		{
			currentScanDuration = 0f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			DrawCircle(agent.transform.position, currentScanRadiusBB.value, scanColour, numberOfScanCirclePoints);

			currentScanDuration += Time.deltaTime;
			if(currentScanDuration > scanDurationInSeconds)
			{
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, currentScanRadiusBB.value, targetLayerMask);
				foreach(Collider collider in colliders)
				{
					Blackboard bb = collider.GetComponentInParent<Blackboard>();
					float repairValue = bb.GetVariableValue<float>("repairValue");

					if (repairValue == 0)
					{
						targetBB.value = bb.GetVariableValue<Transform>("workpad");
						hasTargetBB.value = true;
					}
				}
                EndAction(true);
            }
        }

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour);
			}

			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}