using CodeBrew.Common.Extensions;

namespace CodeBrew.Common.Models;

public class State
{
    #region Public Constructors

    public State(StateEnum abbreviation)
    {
        Abbreviation = abbreviation;
        Name = abbreviation.GetDescription();
    }

    public State()
    {
    }

    #endregion Public Constructors

    #region Public Properties

    public StateEnum Abbreviation { get; set; }
    public string? Name { get; set; }

    public override string ToString()
    {
        return Name ?? string.Empty;
    }

    #endregion Public Properties
}

////Create all the state enum for the US with their attributes of Description having abbreviation and name