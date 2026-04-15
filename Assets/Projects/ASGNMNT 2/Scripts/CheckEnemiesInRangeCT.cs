using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckEnemiesInRangeCT : ConditionTask {

		public BBParameter<float> AARange;
		public BBParameter<GameObject> target;
		private float teamLayer;
		public bool checkForAlliesInstead;
		public LayerMask enemyLayerMask;
		protected override string OnInit(){
			teamLayer = agent.GetComponent<BaseStats>().team;
			enemyLayerMask = LayerMask.GetMask(teamLayer == (checkForAlliesInstead? 0 : 1) ? "BlueTeam" : "RedTeam");
			return null;
		}

		protected override void OnEnable() {
			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
			Collider[] detectedEnemyThings = Physics.OverlapSphere(agent.transform.position, AARange.value, enemyLayerMask);
			List<Collider> detectedEnemies = new List<Collider>();

            
            foreach (Collider collider in detectedEnemyThings)
			{
				if (collider.tag != "NeutralMob" && collider.tag != "Portal" && collider.gameObject != agent.gameObject)
				{
					detectedEnemies.Add(collider);
				}
			}
            if (detectedEnemies.Count > 0)
			{
				if (!checkForAlliesInstead) //if not checking for allies, add the detected collider as a target
				{
                    target.value = detectedEnemies[0].gameObject;
                }
				return true; //there are enemies in range
				
			}
            return false; //there are no enemies in range
		}
	}
}