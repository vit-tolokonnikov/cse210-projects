class ListGoal: Goal
{
    private int _numCompleted = 0;
    private bool _extra = false;

    public override string PrintFullText()
    {
        string text = $"{GetFullText()} -- Currently completed: {_numCompleted} / {GetBonusTimes()}";
        return text;
    }

    public override void SetNumCompleted()
    {
        if (GetBonusTimes() > _numCompleted && IsCompleted() != "x")
        {
            _numCompleted = _numCompleted + 1;

            if (GetBonusTimes() == _numCompleted)
            {
                SetExtra();
            }
        }
    }
    
    public void SetExtra()
    {
        _extra = true;
    }
    
    public override bool GetExtra()
    {
        return _extra;
    }

    public override void SetNumCompletedFromFile(int num)
    {
        _numCompleted = num;
    }

    public override string PrepareForSaving()
    {
        return $"{GetTypeGoal()};{GetGoalName()};{GetGoalDescription()};{GetPoints()};{IsCompleted()};{_numCompleted};{GetExtaBonus()};{GetBonusTimes()}";
    }
}