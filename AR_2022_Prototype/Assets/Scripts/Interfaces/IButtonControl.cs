using System;

namespace AR_PROTO
{
    public interface IButtonControl
    {
        event Action ObjectIsBeingCreated;
        event Action<EState> SwitchesToDrawState;
        event Action<EState> SwitchesToUsingState;
        event Action<bool> BeingDestroyed;
    }
}
