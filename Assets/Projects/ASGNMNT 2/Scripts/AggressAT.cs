using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AggressAT : ActionTask {

		public Transform AggressWaypoint;
		public BBParameter<float> moveSpeed;
		public float choiceRadius, arrivalThreshold;
		private Vector3 moveTo;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			float choiceX = Random.Range(0, choiceRadius);
            float choiceZ = Random.Range(0, choiceRadius);

			moveTo = new Vector3(choiceX, agent.transform.position.y, choiceZ) + AggressWaypoint.position;
        }

		protected override void OnUpdate() {
			Vector3 direction = (moveTo - agent.transform.position).normalized;
			agent.transform.position += direction * moveSpeed.value * Time.deltaTime;

			if (Vector3.Distance(agent.transform.position, moveTo) < arrivalThreshold) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}