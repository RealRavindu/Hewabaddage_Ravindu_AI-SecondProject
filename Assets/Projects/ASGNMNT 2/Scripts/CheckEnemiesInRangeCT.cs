using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckEnemiesInRangeCT : ConditionTask {

		public BBParameter<float> AARange;
		public BBParameter<GameObject> target;
		private float teamLayer;
		public LayerMask enemyLayerMask;
		protected override string OnInit(){
			teamLayer = agent.GetComponent<BaseStats>().team;
			enemyLayerMask = LayerMask.GetMask(teamLayer == 1 ? "BlueTeam" : "RedTeam");
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
				return false; 
			}
            Debug.Log("I've not detected an enemy");
            return true;
		}
	}
}