using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<GameStep> stepSequence;

    private int currentStep = 0;

    public int startStepOffset = 0;

    public bool toToggleAllInactiveStepsOnStart = true;

    // Start is called before the first frame update
    void Start()
    {
        currentStep = startStepOffset < stepSequence.Count ? startStepOffset : 0;
        currentStep = startStepOffset < 0 ? 0 : startStepOffset;

        if(toToggleAllInactiveStepsOnStart)
        {
            int i = 0;
            foreach(var step in stepSequence)
            {
                step.gameObject.SetActive(i == currentStep);
                ++i;
            }
        }

        stepSequence[currentStep].onStepBegin.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStep < stepSequence.Count && stepSequence[currentStep].CheckComplete())
            NextStep();
    }

    private void NextStep()
    {
        stepSequence[currentStep].onStepComplete.Invoke();
        stepSequence[currentStep].gameObject.SetActive(false);
        ++currentStep;

        if(currentStep < stepSequence.Count)
        {
            stepSequence[currentStep].gameObject.SetActive(true);
            stepSequence[currentStep].onStepBegin.Invoke();
        }
    }
}
