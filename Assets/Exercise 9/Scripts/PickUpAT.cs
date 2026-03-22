using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PickUpAT : ActionTask {

		public float grabDistance, holdDistance;
		public LayerMask garbageLayer;
		BBParameter<Vector3> destination;
		private Blackboard blackboard;
		public GarbageSpawner garbageSpawner;
		protected override string OnInit() {
			blackboard = agent.GetComponent<Blackboard>();
			return null;
		}

		protected override void OnExecute() {

			//checking for garbage aroudn the player in radius 'grabDistance'
			Collider[] detectedGarbage = Physics.OverlapSphere(agent.transform.position, grabDistance, garbageLayer);
			Debug.Log("how many garbage detected: " + detectedGarbage.Length);
			
			if (detectedGarbage.Length == 0) EndAction(false); //if didnt detect any garbage around the player


            Transform garbage = detectedGarbage[0].transform; //select the first detected garbage
            garbage.transform.position = agent.transform.position + agent.transform.forward * holdDistance; //position it infront of the player, 'holdDistance' away from them.
            garbage.parent = agent.transform; //set the garbage's parent as the player so that it follows them when they move/ rotate.
            blackboard.SetVariableValue("garbageInHand", garbage.gameObject); //set it as a blackboard variable so that the next script (disposeAT) can reference that when it tries to throw the garbage.
			Debug.Log("Before removing: " + garbageSpawner.spawnedGarbageList.Count);
            garbageSpawner.spawnedGarbageList.Remove(garbage); //removing the garbage from the list so that it doesn't try to get re-selected when it's null (since deleted by void)
			Debug.Log("after removing: " +garbageSpawner.spawnedGarbageList.Count);
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