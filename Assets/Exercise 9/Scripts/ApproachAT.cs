using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public float arrivalThreshold;
        public BBParameter<Vector3> destination;

        private NavMeshAgent navAgent;
        public GarbageSpawner garbageSpawner;


        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			navAgent.SetDestination(destination.value);
		}

		protected override void OnUpdate() {
			Debug.Log((agent.transform.position - navAgent.destination).magnitude);
			if ((agent.transform.position - navAgent.destination).magnitude < arrivalThreshold) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}