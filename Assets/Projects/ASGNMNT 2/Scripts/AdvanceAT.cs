using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AdvanceAT : ActionTask {
		private Transform portalTransform;
		public BBParameter<float> moveSpeed;
		public float arrivalThreshold;
		private int teamLayer;
		protected override string OnInit() {

			teamLayer = agent.gameObject.layer;
			GameObject[] portalObjects = GameObject.FindGameObjectsWithTag("Portal");
            portalTransform = (portalObjects[0].layer == teamLayer) ? portalObjects[1].transform : portalObjects[0].transform;
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
			Score score = portalTransform.GetComponent<Score>();
			score.score++;
			GameObject.Destroy(agent.gameObject);
		}

		protected override void OnPause() {
			
		}
	}
}