using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public BBParameter<Transform> destinationTransform;
		public float stoppingDistanceFromDest;
		private NavMeshAgent navAgent;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			Vector3 displacement = destinationTransform.value.position - agent.transform.position;
			Vector3 destination = displacement - Vector3.one * stoppingDistanceFromDest;
			navAgent.SetDestination(destination);
			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}