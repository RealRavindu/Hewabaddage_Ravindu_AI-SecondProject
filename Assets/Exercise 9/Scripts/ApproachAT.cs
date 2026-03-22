using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public float stoppingDistanceFromDest, arrivalThreshold;
        private Vector3 destination;

        private NavMeshAgent navAgent;
        public GarbageSpawner garbageSpawner;


        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			if (garbageSpawner.spawnedGarbageList.Count < 1 || garbageSpawner.spawnedGarbageList[0] == null) EndAction(false);
			destination = garbageSpawner.spawnedGarbageList[0].position;
			destination.y = 0;
			navAgent.SetDestination(destination);
		}

		protected override void OnUpdate() {
			if ((agent.transform.position - navAgent.destination).magnitude < arrivalThreshold) EndAction(true);
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}