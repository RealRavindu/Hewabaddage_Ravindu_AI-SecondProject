using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class DisposeAT : ActionTask {

		public float force;
		GameObject garbageInHand;
		public GarbageSpawner garbageSpawner;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			garbageInHand = agent.transform.GetChild(agent.transform.childCount - 1).gameObject;
			Vector3 directionToCenter = (-agent.transform.position).normalized;
			agent.transform.forward = directionToCenter;

            garbageInHand.transform.parent = null;
            garbageSpawner.spawnedGarbageList.Add(garbageInHand.transform);
            Rigidbody garbageRB = garbageInHand.GetComponent<Rigidbody>();
            garbageRB.AddForce(directionToCenter * force, ForceMode.Impulse);
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