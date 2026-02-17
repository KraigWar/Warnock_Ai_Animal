using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class ArmAnimAT : ActionTask
    {

        private Transform Larm;
        private Transform Rarm;
        public float Xangle;
        public float Yangle;
        public float Zangle;
        protected override string OnInit()
        {

            Larm = GameObject.FindWithTag("Larm").transform;
            Rarm = GameObject.FindWithTag("Rarm").transform;
            return null;
        }


        protected override void OnExecute()
        {

            Larm.transform.Rotate(new Vector3(Xangle, Yangle, Zangle));
            Rarm.transform.Rotate(new Vector3(Xangle, Yangle, Zangle));
            
        }

        protected override void OnStop()
        {
            Larm.transform.Rotate(new Vector3(-Xangle, -Yangle, -Zangle));
            Rarm.transform.Rotate(new Vector3(-Xangle, -Yangle, -Zangle));
        }

    }
}