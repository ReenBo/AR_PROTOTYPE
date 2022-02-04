using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AR_PROTO.Interface
{
    public interface INode
    {
        bool IsMoved { get; }
        Transform NodeTransform { get; }
        void ChangeColor(bool isSelected);
    }
}
