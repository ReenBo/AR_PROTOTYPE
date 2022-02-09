namespace AR_PROTO
{
    public interface IState
    {
        void ChangeState(EState state);
        EState GetState();
    }
}
