using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObject
{

    T AddComponent<T>();

    Transform transform { get; }

}
