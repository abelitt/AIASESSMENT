using UnityEngine;

/// <summary>
/// The flag is a collectable object, The flag is still rendered when carried to
/// aid debugging. The flag is also slightly raised when carried. 
/// </summary>
public class Flag : Collectable
{
    // how much to raise the flag when carrying it
    private const float flagRaiseAmount = 1;

    /// <summary>
    /// An AI agent collects the flag
    /// </summary>
    /// <param name="agentData">The agent collecting the flag</param>
    public override void Collect(AgentData agentData)
    {
        // Not collideable, but still rendered
        gameObject.transform.parent = agentData.transform;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        // Flag is raised when carried
        Vector3 flagPosition = gameObject.transform.position;
        flagPosition.y += flagRaiseAmount;
        gameObject.transform.position = flagPosition;

        // not visible to AIs but AI's know it's being carried
        gameObject.layer = 0;
    }

    /// <summary>
    /// An AI agent drops the flag in a specified position
    /// </summary>
    /// <param name="agentData">The agent dropping the flag</param>
    /// <param name="position">The position its being dropped in</param>
    public override void Drop(AgentData agentData, Vector3 position)
    {
        // Collidable again
        gameObject.transform.parent = null;
        gameObject.GetComponent<BoxCollider>().enabled = true;

        // no longer raised
        Vector3 flagPosition = position;
        flagPosition.y -= flagRaiseAmount;
        gameObject.transform.position = flagPosition;

        // Becomes visible to AIs and they know it's not carried
        gameObject.layer = LayerMask.NameToLayer("VisibleToAI");
    }
}
