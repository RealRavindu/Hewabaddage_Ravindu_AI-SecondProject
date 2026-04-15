using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class IsPlayerInRangeCT : ConditionTask {
		public BBParameter<Transform> playerTransform;
		public BBParameter<float> QRange;
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (Vector2.Distance(playerTransform.value.position, agent.transform.position) < QRange.value) return true;
			else return false;
		}
	}
}