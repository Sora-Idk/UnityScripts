using UnityEngine;

//Add a script to the object you want to make interactable and in it make a function called Interact() this will be called.
public class AbilityToInteract : MonoBehaviour
{
    public float interactionDistance = 3.0f; //Interactable distance
    public Camera playerCamera; // Reference to the player's camera
    public string Tag;//name of tag
    public KeyCode interactionKey = KeyCode.E;

    void Update()
    {
        //creates a ray location
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        //stores the value captured by ray
        RaycastHit hit;

        //casts the ray at pos ray and stores info in hit, length of ray = interactionDistance
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            //stores data of obj that collided with the ray
            GameObject hitObject = hit.collider.gameObject;

            // Check to see if the object is interactable ifso executes the script with Interact() function
            if (hitObject.CompareTag(Tag))
            {
                if (Input.GetKeyDown(interactionKey))
                    ExecuteInteractMethod(hitObject);
            }
        }

        //whenever executed goes trhough all the scripts attached to the targetObject to find one with method "Interact" and executes it
        void ExecuteInteractMethod(GameObject targetObject)
        {
            MonoBehaviour[] scripts = targetObject.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour script in scripts)
            {
                System.Type scriptType = script.GetType();
                System.Reflection.MethodInfo method = scriptType.GetMethod("Interact");

                if (method != null)
                {
                    method.Invoke(script, null);
                    break; // Only execute the first script with an "Interact" method
                }
            }
        }
    }
}
