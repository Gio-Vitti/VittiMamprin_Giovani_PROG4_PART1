using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RepairAT : ActionTask {

		public BBParameter<float> initialScanRadiusBB;
        public BBParameter<float> currentScanRadiusBB;
		public BBParameter<Transform> targetBB;
		public BBParameter<bool> targetFoundBB;

		public float repairRate = 25f;

		private Blackboard lightTowerBoard;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
			lightTowerBoard = targetBB.value.GetComponent<Blackboard>();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			float repairValue = lightTowerBoard.GetVariableValue<float>("repairValue");

			repairValue += repairRate * Time.deltaTime;
			lightTowerBoard.SetVariableValue("repairValue", repairValue);

			if (repairValue >= 50)
			{
				targetFoundBB.value = false;
				currentScanRadiusBB.value = initialScanRadiusBB.value;
				EndAction(true);
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