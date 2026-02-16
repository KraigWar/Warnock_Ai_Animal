using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FaceTree : ActionTask {

		public BBParameter<Transform> treeToPunch;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() 
		{
			agent.transform.LookAt(new Vector3(treeToPunch.value.transform.position.x, agent.transform.position.y, treeToPunch.value.transform.position.z));
			EndAction(true);
		}
	}
}