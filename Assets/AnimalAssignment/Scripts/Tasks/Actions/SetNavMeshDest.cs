using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SetNavMeshDest : ActionTask {
		//get the nav agent and the new destination for the animal
        private NavMeshAgent navAgent;
		public BBParameter<Vector3> dest;

        protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		
		protected override void OnExecute() {
			//set up the new destination for the animal to be in this case, the tree
            navAgent.SetDestination(dest.value);
            EndAction(true);
		}
	}
}