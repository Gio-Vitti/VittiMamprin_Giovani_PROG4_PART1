using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {
		public BBParameter<Transform> targetBB;
		public BBParameter<float> currentScanRadiusBB;
		public BBParameter<float> initialScanRadiusBB;
		public BBParameter<bool> foundTargetBB;

        public Color scanColour;
		public int numberOfScanCirclePoints;
		public LayerMask lm;
		public float scanDurationInSec;
		private Ray scanRay;

		private float currentScanDuration = 0f;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            currentScanRadiusBB.value = initialScanRadiusBB.value;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			currentScanDuration = 0f;
			//currentScanRadiusBB.value = initialScanRadiusBB.value;

			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			DrawCircle(agent.transform.position, currentScanRadiusBB.value, scanColour, numberOfScanCirclePoints);

			currentScanDuration += Time.deltaTime;
			if (currentScanDuration > scanDurationInSec)
			{
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, currentScanRadiusBB.value, lm);
                if (colliders.Length == 0)
                {
                    foundTargetBB.value = false;
                }

                foreach (Collider collider in colliders)
				{
                    
                    Blackboard bb = collider.GetComponentInParent<Blackboard>();
					float repairValue = bb.GetVariableValue<float>("repairValue");

					if (repairValue == 0)
					{
						targetBB.value = bb.GetVariableValue<Transform>("workpad");
                        foundTargetBB.value = true;
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