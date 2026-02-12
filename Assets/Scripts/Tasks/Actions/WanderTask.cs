using NodeCanvas.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderTask : ActionTask 
	{
		public BBParameter<float> timeSinceLastSampleBBP;
		public BBParameter<Vector3> TargetPositionBBP;
		public BBParameter<bool> isMovingBBP;
		public BBParameter<float> DistanceToTree;
		public LayerMask treeMask;

		public float wanderDistance = 4f;
		public float wanderRadius = 3f;

		
		protected override void OnUpdate() 
		{
			

                if (timeSinceLastSampleBBP.value == 0 && isMovingBBP.value == true)
			{
				Vector3 destination = CalulateTargetPosition();
				if(NavMesh.SamplePosition(destination, out NavMeshHit hitInfo, wanderDistance + wanderRadius, NavMesh.AllAreas))
				{
					TargetPositionBBP.value = hitInfo.position;
				}
			}
		}

		private Vector3 CalulateTargetPosition()
		{
			Vector3 circleCenter = agent.transform.position +agent.transform.forward * wanderDistance;
			Vector3 randomPoint = Random.insideUnitSphere.normalized * wanderRadius;  

			Vector3 destination = circleCenter + randomPoint;

			return destination;
		}

	}
}