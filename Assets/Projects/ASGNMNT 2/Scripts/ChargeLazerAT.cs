using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Rendering;

namespace NodeCanvas.Tasks.Actions {

	public class ChargeLazerAT : ActionTask {

		public GameObject lazerSignifierPrefab;
		public GameObject lazerPrefab;
		private GameObject lazerSignifier;
		public float firingOffset;
		public float chargeTime;
		private float timePassed;
		public BBParameter<Vector3> targetPos;
		public BBParameter<float> QRange;
		public BBParameter<float> QDamage;
        private Vector3 directionToFire;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timePassed = 0;

            directionToFire = targetPos.value - agent.transform.position;
			directionToFire.y = 0.1f;
            agent.transform.forward = new Vector3(directionToFire.x, agent.transform.forward.y, directionToFire.z); //faces target

            lazerSignifier = GameObject.Instantiate(lazerSignifierPrefab);
			lazerSignifier.transform.forward = Vector3.Cross(lazerSignifier.transform.up, directionToFire).normalized;
			lazerSignifier.transform.position = agent.transform.position + directionToFire.normalized * firingOffset;
		}

		protected override void OnUpdate() {
			timePassed += Time.deltaTime;

			if (timePassed > chargeTime) EndAction(true);
		}

		protected override void OnStop() {
			GameObject.Destroy(lazerSignifier);
            GameObject lazer = GameObject.Instantiate(lazerPrefab);
            lazer.transform.position = agent.transform.position;
            Lazer lazerScript = lazer.GetComponent<Lazer>();
			lazerScript.initiate((directionToFire.normalized * (QRange.value + firingOffset)) + agent.transform.position, QDamage.value);

        }

		protected override void OnPause() {
			
		}
	}
}