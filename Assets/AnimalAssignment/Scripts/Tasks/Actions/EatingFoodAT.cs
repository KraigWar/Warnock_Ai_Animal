using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EatingFoodAT : ActionTask {

		//get the prefab ready
		//set up the timer to to know how long this state will last
		public GameObject fruitPrefab;
		private float destroyTimer;
		private GameObject spawnedFruit;

		//a black board parameter for the SUB FSM to track how many fruits have been eaten to later evolve
		public BBParameter<float> fruitsEaten;

		//booleans to leave this state either to go back to wandering, or to begin evolving
		public BBParameter<bool> hasEaten;
		public BBParameter<bool> evolving;

		protected override string OnInit() {
			//make evolving false initially just in case
            evolving.value = false;
			return null;
		}

		
		protected override void OnExecute() {
			//increase the amount eaten by 1
            fruitsEaten.value++;
			
			//start the timer to make it seems like the fruit takes time to be eaten
			destroyTimer = 0;
			//make sure that it knows its not done eating yet
			hasEaten.value = false;
			//spawn the fruit to be eaten above the animal
			spawnedFruit = GameObject.Instantiate(fruitPrefab);
			spawnedFruit.transform.position = new Vector3(agent.transform.position.x, agent.transform.position.y + 2.75f, agent.transform.position.z);

            
		}


		protected override void OnUpdate()
		{
           //begin the timer and when it reaches 5 seconds destroy the object and say your done eating
            destroyTimer += Time.deltaTime;
			if (destroyTimer > 5)
			{
				GameObject.Destroy(spawnedFruit);
                hasEaten.value = true;
                
            }
		}
        protected override void OnStop()
        {
			// when your done the process of eating check if youve eaten enough to evolve and set the boolean that the sub FSM is checking for
            if (fruitsEaten.value == 3)
            {
                evolving.value = true;
            }
        }
	}
}