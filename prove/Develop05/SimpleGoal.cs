class SimpleGoal: Goal
{
    public override string PrepareForSaving()
    {
        return $"{GetTypeGoal()};{GetGoalName()};{GetGoalDescription()};{GetPoints()};{IsCompleted()}";
    }
}