using UnityEngine;


public class Grow : MonoBehaviour
{
    public GameObject text;

    public float growthRate = 1f; // Rate at which the character grows per second
    public float maxScale = 20f; // Maximum scale for the character

    private bool isGrowing = true; // Flag to control growth

   

    public GameObject Obj;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial scale of the character
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            // Calculate the new scale based on the growth rate and time
            Vector3 newScale = transform.localScale + (Vector3.one * growthRate * Time.deltaTime);

            // Restrict the scale to the maximum value
            newScale = Vector3.Min(newScale, Vector3.one * maxScale);

            // Update the scale
            transform.localScale = newScale;

            // Check if the character has reached the maximum scale
            if (transform.localScale.y >= maxScale)
            {
                // Perform "blow up" effect or destruction logic
                BlowUp();
            }
        }

       
    }

    private void BlowUp()
    {
        // Perform any blow-up effect here, such as playing an explosion animation or particle effect

        // Destroy the character game object
        gameObject.SetActive(false);

        text.SetActive(true);
        Instantiate(Obj, transform.position, Quaternion.identity);
    }
}
