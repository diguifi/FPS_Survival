﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}

public class MouseAxis
{
    public const string MOUSE_X = "Mouse X";
    public const string MOUSE_Y = "Mouse Y";
}

public class AnimationTags
{
    public const string SHOOT_TRIGGER = "Shoot";
}

public enum MovementTypes
{
    Sprinting,
    Walking,
    Crouching
}
