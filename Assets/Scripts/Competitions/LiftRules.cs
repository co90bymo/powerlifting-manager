using UnityEngine;

public static class LiftRules
{
    public const float Increment = 2.5f;

    public static float RoundToIncrement(float weight)
    {
        return Mathf.Round(weight / Increment) * Increment;
    }


    public static bool IsLegalAttempt(
        float enteredWeight,
        CompetitionAttempt previousAttempt,
        LiftType liftType)
    {
        UnityEngine.Debug.Log("Inside LiftRules:");
        // Opening attempt
        if (previousAttempt == null)
        {
            UnityEngine.Debug.Log("previousAttempt = null");
            return enteredWeight > 0 && Mathf.Abs(enteredWeight % Increment) < 0.01f;
        } else
        {
            UnityEngine.Debug.Log("previousAttempt = not null");
            float previousWeight;
            bool previousSuccess;

            switch (liftType)
            {
                case LiftType.Squat:
                    previousWeight = previousAttempt.Squat;
                    previousSuccess = previousAttempt.SuccessSquat;
                    break;

                case LiftType.Bench:
                    previousWeight = previousAttempt.Bench;
                    previousSuccess = previousAttempt.SuccessBench;
                    break;

                default:
                    previousWeight = previousAttempt.Deadlift;
                    previousSuccess = previousAttempt.SuccessDeadlift;
                    break;
            }

            if (enteredWeight < previousWeight)
            {
                UnityEngine.Debug.Log("Entered Weight < Previous Weight");
                UnityEngine.Debug.Log(enteredWeight);
                UnityEngine.Debug.Log(previousWeight);
                return false;
            }

            if (enteredWeight == previousWeight && previousSuccess)
            {
                UnityEngine.Debug.Log("Entered Weight = Previous Weight && Successfull");
                UnityEngine.Debug.Log(enteredWeight);
                UnityEngine.Debug.Log(previousWeight);
                UnityEngine.Debug.Log(previousSuccess);
                return false;
            }
            UnityEngine.Debug.Log("Increment Check:");
            UnityEngine.Debug.Log(enteredWeight);
            UnityEngine.Debug.Log(Increment);
            UnityEngine.Debug.Log(enteredWeight % Increment);

            return Mathf.Abs(enteredWeight % Increment) < 0.01f;
        }
    }
}