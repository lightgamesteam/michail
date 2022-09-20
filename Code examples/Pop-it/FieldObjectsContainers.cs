using UnityEngine;

[System.Serializable]
public class FieldObjectsContainers
{
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject vfx;

    public FieldObjectsContainers()
    {

    }

    public void InstanceContainers(Transform parent)
    {
        InstanceRoot(parent);
        InstanceBall();
        InstanceVfx();
    }

    private void InstanceRoot(Transform parent)
    {
        if (root != null)
        {
            return;
        }
        root = new GameObject("root");
        root.gameObject.transform.parent = parent;
    }

    private void InstanceBall()
    {
        if (ball != null)
        {
            return;
        }
        ball = InstanceContainer("ball", ViewDepth.BALL);
    }

    private void InstanceVfx()
    {
        if (vfx != null)
        {
            return;
        }
        vfx = InstanceContainer("vfx", ViewDepth.VFX);
    }

    private GameObject InstanceContainer(string name, float zPosition)
    {
        var result = new GameObject(name);
        result.transform.parent = root.gameObject.transform;
        result.transform.position = new Vector3(result.transform.position.x, result.transform.position.y, zPosition);

        return result;
    }

    public GameObject Root { get => root; }
    public GameObject Ball { get => ball; }
    public GameObject Vfx { get => vfx; }
}