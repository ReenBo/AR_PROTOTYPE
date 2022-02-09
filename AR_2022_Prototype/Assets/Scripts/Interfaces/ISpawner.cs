using UnityEngine;

namespace AR_PROTO
{
    public interface ISpawner
    {
        void Init(IButtonControl buttonControl);
        void CreateObject();
    }
}

