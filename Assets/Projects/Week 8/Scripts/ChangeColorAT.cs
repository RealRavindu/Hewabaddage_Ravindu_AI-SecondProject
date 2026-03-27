using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeColorAT : ActionTask {

		public Color color;
		private MeshRenderer meshRenderer;

		protected override string OnInit() {
			meshRenderer = agent.GetComponent<MeshRenderer>();
			return null;
		}

		protected override void OnExecute() {
			meshRenderer.material.color = color;
			EndAction(false);
		}


		protected override void OnUpdate() {
			
		}


		protected override void OnStop() {
			
		}


		protected override void OnPause() {
			
		}
	}
}