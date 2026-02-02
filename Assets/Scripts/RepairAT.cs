using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class RepairAT : ActionTask
    {
        public BBParameter<float> initialScanRadiusBBP;
        public BBParameter<float> currentScanRadiusBBP;
        public BBParameter<Transform> targetBBP;
        public BBParameter<bool> hasTargetBBP;

        public float repairRate = 25;

        private Blackboard lightTowerBB;

        protected override void OnExecute()
        {
            lightTowerBB = targetBBP.value.GetComponentInParent<Blackboard>();
        }

        protected override void OnUpdate()
        {
            float repairValue = lightTowerBB.GetVariableValue<float>("repairValue");
            repairValue += repairRate * Time.deltaTime;
            lightTowerBB.SetVariableValue("repairValue", repairValue);

            if(repairValue >= 100)
            {
                hasTargetBBP.value = false;
                currentScanRadiusBBP.value = initialScanRadiusBBP.value;
                EndAction(true);
            }
        }
    }
}
