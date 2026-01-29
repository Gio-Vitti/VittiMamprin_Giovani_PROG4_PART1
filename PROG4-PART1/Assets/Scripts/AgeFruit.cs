using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AgeFruit : ActionTask {

		public BBParameter<float> expiryTimeBB;
		public BBParameter<float> timeLimitBB;
		public BBParameter<bool> IsSpoiled;
		private SpriteRenderer sr;
		private float c;
		

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
			expiryTimeBB.value = timeLimitBB.value;
			sr = agent.GetComponent<SpriteRenderer>();
			IsSpoiled.value = false;

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			//Timer
			expiryTimeBB.value -= Time.deltaTime;
			c = expiryTimeBB.value / timeLimitBB.value;

			//Change colour:
			sr.color = new Color(c, c, c);
			
		}
	}
}