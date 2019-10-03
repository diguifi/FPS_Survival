using System.Collections;
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
    public const string DRAW_STATE = "Draw";
    public const string IDLE_STATE = "Idle";
    public const string ATTACK_STATE = "Attack";
    public const string WALK_STATE = "Walk";
    public const string RUN_STATE = "Run";
    public const string DEAD_STATE = "Dead";
    public const string ZOOM_IN = "ZoomIn";
    public const string ZOOM_OUT = "ZoomOut";

}

public class Tags
{
    public const string AXE = "Axe";
    public const string CROSSHAIR = "Crosshair";
    public const string POV = "POV";
    public const string ZOOM_CAMERA = "FPCamera";
    public const string MAIN_CAMERA = "Main Camera";
    public const string PLAYER = "Player";
}

public enum MovementTypes
{
    Sprinting,
    Walking,
    Crouching
}
