using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


public class DistanceCheck : MonoBehaviour
{
    public Blackboard blackboard;
    private bool tooClose;
    private bool tooFar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tooClose = blackboard.GetVariableValue<bool>("tooClose");
        tooFar = blackboard.GetVariableValue<bool>("tooFar");
    }

    public void CloseTrue()
    {
        tooClose = true;
        blackboard.SetVariableValue("tooClose", tooClose);
    }

    public void CloseFalse()
    {
        tooClose = false;
        blackboard.SetVariableValue("tooClose", tooClose);
    }

    public void FarTrue()
    {
        tooFar = true;
        blackboard.SetVariableValue("tooFar", tooFar);
    }

    public void FarFalse()
    {
        tooFar = false;
        blackboard.SetVariableValue("tooFar", tooFar);
    }
}
