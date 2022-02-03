using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO.Interface
{
    public interface INode
    {
        bool IsMoved { get; }
        Transform NodeTarget { get; }
        void ChangeColor(bool isSelected);
    }
}
