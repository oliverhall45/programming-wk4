using UnityEngine;

public static class SteeringUtility
{
    public static Vector3 Seek(Vector3 position, Vector3 target)
    {
        return (target - position).normalized;
    }

    public static Vector3 Flee(Vector3 position, Vector3 target)
        => Seek(target, position);
}
