using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckEnemiesInRangeCT : ConditionTask {

		public BBParameter<float> AARange;
		public BBParameter<GameObject> target;
		public LayerMask enemyLayerMask, allyLayerMask;
		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			Collider[] detectedEnemies = Physics.OverlapSphere(agent.transform.position, AARange.value, enemyLayerMask);
			if (detectedEnemies.Length > 0)
			{
				Debug.Log("I've detected an enemy");
				target.value = detectedEnemies[0].gameObject;
				return true; 
			}
            Debug.Log("I've not detected an enemy");
            return false;
		}
	}
}