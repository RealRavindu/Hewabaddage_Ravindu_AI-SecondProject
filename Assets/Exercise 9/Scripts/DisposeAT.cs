using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem.Android;


namespace NodeCanvas.Tasks.Actions {

	public class DisposeAT : ActionTask {

		private Blackboard blackboard;
		public float force;
		public BBParameter<GameObject> garbageInHand;
		public GarbageSpawner garbageSpawner;
		protected override string OnInit() {
			blackboard = agent.GetComponent<Blackboard>();
			return null;
		}

		protected override void OnExecute() {

			
			Vector3 directionToCenter = (-agent.transform.position).normalized; //getting the direction to the center. Since the center is (0,0,0), it's just whatever position multiplied by -1
            agent.transform.forward = directionToCenter; //face the center
            garbageInHand.value.transform.parent = null; //unlinking the garbage's parent so that when the garbageman moves, it doesn't randomly move the thrown garbage as well.
            //garbageSpawner.spawnedGarbageList.Add(garbageInHand.value.transform); //re-adding the thrown garbage back into the list, incase it doesn't make it into the bin.

            //getting the rigidbody and applying a force in the direction of the center
            Rigidbody garbageRB = garbageInHand.value.GetComponent<Rigidbody>();
            garbageRB.AddForce(directionToCenter * force, ForceMode.Impulse);

			blackboard.SetVariableValue("garbageInHand", null);
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