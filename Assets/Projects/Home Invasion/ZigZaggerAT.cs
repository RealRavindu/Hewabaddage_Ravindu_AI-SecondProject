using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ZigZaggerAT : ActionTask {

		public BBParameter<Transform> homeOwnerTransform;
		public float timeToReach, timePassed, amplitude, speed, frequency;
		private Rigidbody rb;
		protected override string OnInit() {
			rb =agent.GetComponent<Rigidbody>();
			return null;
		}
		protected override void OnExecute() {
			timePassed = 0;
			agent.transform.LookAt(homeOwnerTransform.value.position);
		}

		protected override void OnUpdate() {
			timePassed += Time.deltaTime/timeToReach;
			Vector3 direction = (homeOwnerTransform.value.position - agent.transform.position).normalized;
			direction = Quaternion.Euler(0, Mathf.Sin(timePassed*frequency)*amplitude,0) * direction;
			agent.transform.forward = direction;
			
			rb.AddForce(agent.transform.forward*speed*Time.deltaTime, ForceMode.Impulse);
			if (timePassed > Mathf.PI*2) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}