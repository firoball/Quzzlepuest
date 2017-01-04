﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interfaces
{
    public interface ITokenMoveEventTarget : IEventSystemHandler
    {
        void OnMoveTo(Vector3 newPosition);
    }
}
