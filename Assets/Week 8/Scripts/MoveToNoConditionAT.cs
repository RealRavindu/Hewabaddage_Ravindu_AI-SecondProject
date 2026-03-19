using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToNoConditionAT : ActionTask {

		public Transform destination;
		public float speed;
		public float arrivalThreshold;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

		}

		protected override void OnUpdate() {
			Vector3 direction = (destination.position - agent.transform.position).normalized;
			agent.transform.position += direction * speed * Time.deltaTime;

			if ((agent.transform.position - destination.position).magnitude < arrivalThreshold) EndAction(true);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}