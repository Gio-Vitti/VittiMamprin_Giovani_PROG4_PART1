using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using System.Collections;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

		public GameObject bed;
		public BBParameter<float> sleepTimeBB;
		public BBParameter<float> shiftTimerBB;
		public BBParameter<float> shiftDurationBB;
		public BBParameter<bool> isSleeping;
		public BBParameter<bool> isWorking;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			isSleeping.value = true;
			isWorking.value = false;
			agent.transform.eulerAngles = new Vector3 (90,0,0);
			bed = GameObject.Instantiate(bed, new Vector3 (agent.transform.position.x, 0, agent.transform.position.z), Quaternion.identity);
			StartCoroutine(Snooze());
		}

		IEnumerator Snooze()
        {
			yield return new WaitForSeconds(sleepTimeBB.value);
			GameObject.Destroy(bed);
			EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			agent.transform.eulerAngles = Vector3.zero;
			shiftTimerBB.value = shiftDurationBB.value;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}