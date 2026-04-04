using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AdvanceAT : ActionTask {
		public Transform portalTransform;
		public BBParameter<float> moveSpeed;
		public float arrivalThreshold;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

		}

		protected override void OnUpdate() {
			Vector3 displacement = portalTransform.position - agent.transform.position;
			agent.transform.position += displacement.normalized * moveSpeed.value * Time.deltaTime;


			if (displacement.magnitude < arrivalThreshold) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}