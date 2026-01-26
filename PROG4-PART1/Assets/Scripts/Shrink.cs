using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Shrink : ActionTask {

		public float maxSize;
		private Vector3 initSize;
		

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute()
		{
			initSize = agent.transform.localScale;
		}


		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if (agent.transform.localScale.magnitude > maxSize)
			{
				agent.transform.localScale -= Vector3.one * Time.deltaTime;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
			agent.transform.localScale = initSize;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}