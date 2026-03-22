using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ConfusedAT : ActionTask {

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			Debug.Log("WHERE IS THE TRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAASH?!?!??!");
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