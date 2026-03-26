using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PlayerCloseCT : ConditionTask {
		public BBParameter<Transform> homeOwnerTransform;
		public float dashDistance;
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			if (Vector3.Distance(agent.transform.position, homeOwnerTransform.value.position) < dashDistance)
			{
				return true;
			}
			else return false;
		}
	}
}