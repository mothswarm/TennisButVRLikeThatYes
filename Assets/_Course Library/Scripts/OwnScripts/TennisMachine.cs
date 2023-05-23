using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TennisMachine : MonoBehaviour
{
    // Gizmo
    [SerializeField] Transform[] gizmoPoints; // Add Gizmo Points here
    private int currentPointIndex;
    private Vector3 currentPoint;
    public float distance = 1;

    // Tennis ball and machine speed
    [SerializeField] float speed = 10f;
    Rigidbody rB;

    // Tennis ball reference
    [SerializeField] GameObject shootTennisBall;

    // Shooting
    public float shootingRange = 10f;
    public float bulletsBeforeReloading = 30f;
    public float shootingDurationBetweenBullets1 = 1;
    public float shootingDurationBetweenBullets2 = 5;
    public float reloadDuration = 5f;
    private bool isReloading = false;

    public GameObject projectilePrefab;
    private bool isShooting = false;
    public GameObject gun;
    public GameObject gunPoint;
    public float shootingSpeed = 15f;

    // Text
    [SerializeField] TextMeshProUGUI barText;
    public GameObject barObj;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();

        if (gizmoPoints.Length > 0)
        {
            currentPointIndex = 0;
            currentPoint = gizmoPoints[currentPointIndex].position;
        }

        barText.text = "0";
        barObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBetweenPoints();
    }

    private void MoveBetweenPoints()
    {
        if (gizmoPoints.Length > 0)
        {
            float toPoint = Vector3.Distance(currentPoint, transform.position);
            if (toPoint <= distance)
            {
                currentPointIndex++;
                if (currentPointIndex >= gizmoPoints.Length)
                {
                    currentPointIndex = 0;
                }
                currentPoint = gizmoPoints[currentPointIndex].position;
            }
            Vector3 moveDir = currentPoint - transform.position;
            rB.velocity = new Vector3(moveDir.x, rB.velocity.y, moveDir.z).normalized * speed;

            if (!isShooting && !isReloading)
            {
                isShooting = true;
                StartCoroutine(BallRoutine());
            }
        }
    }

    private IEnumerator BallRoutine()
    {
        for (int i = 0; i < bulletsBeforeReloading; i++)
        {
            ShootTennisBall();
         float RandomBullets = Random.Range(shootingDurationBetweenBullets1, shootingDurationBetweenBullets2);
            yield return new WaitForSeconds(RandomBullets);
        }

        barObj.SetActive(true);
        float remainingTime = reloadDuration;

        isReloading = true;
        isShooting = false;

        while (remainingTime > 0)
        {
            barText.text = remainingTime.ToString();
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        barText.text = "0";
        isReloading = false;
        barObj.SetActive(false);
    }

    public void ShootTennisBall()
    {
        // Instantiate and shoot a projectile towards the player
        GameObject projectile = Instantiate(projectilePrefab, gunPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * shootingSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (gizmoPoints.Length > 1)
        {
            for (int i = 0; i < gizmoPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(gizmoPoints[i].position, gizmoPoints[i + 1].position);
            }

            if (gizmoPoints.Length > 2)
            {
                Gizmos.DrawLine(gizmoPoints[gizmoPoints.Length - 1].position, gizmoPoints[0].position);
            }
        }
    }

}
