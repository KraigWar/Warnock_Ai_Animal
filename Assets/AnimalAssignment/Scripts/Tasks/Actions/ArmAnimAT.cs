using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class ArmAnimAT : ActionTask
    {
        //Setting up all the transforms for the arms of the model as well the x y z if I want to change each
        private Transform Larm;
        private Transform Rarm;
        public float Xangle;
        public float Yangle;
        public float Zangle;
        protected override string OnInit()
        {
            //grab the left and right arm game objects and their transforms
            Larm = GameObject.FindWithTag("Larm").transform;
            Rarm = GameObject.FindWithTag("Rarm").transform;
            return null;
        }


        protected override void OnExecute()
        {
            //when this state exectures, make the rotation of the arms what I set in the specific state
            Larm.transform.Rotate(new Vector3(Xangle, Yangle, Zangle));
            Rarm.transform.Rotate(new Vector3(Xangle, Yangle, Zangle));
            
        }

        protected override void OnStop()
        {
            //when you leave the state, put the arms back to their positions by subtracting the changed value
            Larm.transform.Rotate(new Vector3(-Xangle, -Yangle, -Zangle));
            Rarm.transform.Rotate(new Vector3(-Xangle, -Yangle, -Zangle));
        }

    }
}