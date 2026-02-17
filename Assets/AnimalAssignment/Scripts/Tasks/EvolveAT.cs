using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class EvolveAT : ActionTask {

		public BBParameter<bool> finishedEvo;
		private float timeForEvolve;

		protected override string OnInit() {
			return null;
		}


		protected override void OnExecute() {

			agent.transform.localScale = agent.transform.localScale + new Vector3(2, 2, 2) / 4;

			
		}


		protected override void OnUpdate()
		{

			timeForEvolve += Time.deltaTime;
			if (timeForEvolve > 3f)
			{
				finishedEvo.value = true;
            }
		}
	}
}