using UnityEngine;
using Pathfinding;

public class Dragon_Pathfinding : MonoBehaviour
{

    public AIPath aiPath;
    public static float x;
    
    // Update is called once per frame
    void Update()
    {
        x = aiPath.desiredVelocity.x;

        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
