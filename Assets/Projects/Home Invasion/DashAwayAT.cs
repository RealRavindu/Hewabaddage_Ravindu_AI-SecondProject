using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DashAwayAT : ActionTask {

		public BBParameter<Transform> playerTransform;
		private Rigidbody rb;
		public float dashStrength, cooldownTimer, timeSinceDashed;
		protected override string OnInit() {
			rb = agent.GetComponent<Rigidbody>();
			return null;
		}

		protected override void OnExecute() {
			timeSinceDashed = 0;

			Vector3 direction = (agent.transform.position - playerTransform.value.position).normalized;
			//need 90 degrees from this direction
			//for choosing left or right:
			//could see how far the cube has to turn to face the player in either direction, then select the shortest direction and then dash that way
			float turnAmount = (direction - agent.transform.forward).magnitude;
			int mult = (turnAmount < Mathf.PI) ? 1 : -1;
			Vector3 turnDir = Vector3.one * (Mathf.PI / 2);
			turnDir.y = 0;
			Vector3 directionToDash = Vector3.Cross(direction, agent.transform.up);
            //rb.AddForce((direction + turnDir) * mult * dashStrength, ForceMode.Impulse);
            rb.AddForce(directionToDash * dashStrength, ForceMode.Impulse);
            Debug.Log("direction from player to dasher: " + direction + " |dasher's forward dir: " + agent.transform.forward + " |turn amount: " + turnAmount * Mathf.Rad2Deg);
			
		}

		protected override void OnUpdate() {
			timeSinceDashed += Time.deltaTime;
			if (timeSinceDashed > cooldownTimer) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}