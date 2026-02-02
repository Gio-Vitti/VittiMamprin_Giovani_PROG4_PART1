using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAndRotateTowards : ActionTask {

		private float moveSpeed;
		private float turnSpeed;
		private float currentCharge;

		public Transform target;
		public float stoppingDistance = 0.1f;

		private Blackboard agentBoard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			agentBoard = agent.GetComponent<Blackboard>();

			if (agentBoard != null)
			{
				return null;
			}
			else return "Unable to find blackboard component";
		}

        protected override void OnExecute()
        {
			moveSpeed = agentBoard.GetVariableValue<float>("moveSpeed");
            turnSpeed = agentBoard.GetVariableValue<float>("turnSpeed");
			currentCharge = agentBoard.GetVariableValue<float>("currentCharge");

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 direction = target.position - agent.transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(direction);
			agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

			agent.transform.position += moveSpeed * Time.deltaTime * agent.transform.forward;

			//Reduce charge
			currentCharge -= Time.deltaTime;
			agentBoard.SetVariableValue("currentCharge", currentCharge);


			if (Vector3.Distance(agent.transform.position, target.position) <= stoppingDistance)
			{
				EndAction(true);
			}
		}
	}
}