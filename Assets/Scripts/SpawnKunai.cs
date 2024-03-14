using System.Collections.Generic;
using UnityEngine;

public class SpawnKunai : MonoBehaviour
{
    [SerializeField] private float KunaiVelocity;
    public GameObject KunaiPrefab;
    public GameObject kunaiText;
    public GameObject PlayerLocation;
    Rigidbody2D rb2D;
    private List<GameObject> kunaiList = new List<GameObject>();
    public int kunaiCount;
    SpawnKunai sk;
    NumeroDeKunais nmdk;
    [SerializeField] private float kunaiTpSpeed;
    public float rotationBreak;
    public float rotationBreak2;
    private void Start()
    {
        sk = GetComponent<SpawnKunai>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        kunaiCount = SceneControl.kunaiMax;
        kunaiCount = 3;
        nmdk = kunaiText.GetComponent<NumeroDeKunais>();
        if (UpgradeMenu.kunaiOwnedd == false)
        {
            sk.enabled = false;
        }
    }
        private void Update()
    {
        if (kunaiCount < 0)
        {
            kunaiCount = 0;
        }
        if (kunaiCount > SceneControl.kunaiMax)
        {
            kunaiCount = SceneControl.kunaiMax;
        }
        if (Input.GetMouseButtonDown(1) && UpgradeMenu.tpOwnedd)
        {
            Minato();
        }
        if (Input.GetMouseButtonDown(0) && kunaiCount > 0)
        {
            ThrowKunai();
        }

        if (UpgradeMenu.kunaiOwnedd)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }
    }

    public void KunaiThrown()
    {
        kunaiList.Add(null);
    }

    private void ThrowKunai()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (worldMousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject kunaiInst = Instantiate(KunaiPrefab, transform.position, rotation);
        kunaiInst.GetComponent<Rigidbody2D>().velocity = direction * KunaiVelocity;

        kunaiList.Add(kunaiInst);

        kunaiCount -= 1;
        nmdk.kunaiCounts -= 1;
    }

    public void Minato()
    {
        if (kunaiList.Count == 0)
            return;

        GameObject closestKunai = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject kunai in kunaiList)
        {
            if (kunai != null)
            {
                float distance = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), kunai.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestKunai = kunai;
                    rb2D.velocity = new Vector2(closestKunai.GetComponent<Rigidbody2D>().velocity.x, closestKunai.GetComponent<Rigidbody2D>().velocity.y);
                }
            }
        }

        if (closestKunai != null)
        {
            if (closestKunai.transform.localRotation.z > 0 && closestKunai.transform.localRotation.z < 180)
            {
                PlayerLocation.transform.position = closestKunai.transform.position + new Vector3(0, -1, 0);
            }
            if (closestKunai.transform.localRotation.z < 0 && closestKunai.transform.localRotation.z > -180)
            {
                PlayerLocation.transform.position = closestKunai.transform.position + new Vector3(0, 1, 0);
            }

            Destroy(closestKunai);
            kunaiList.Remove(closestKunai);

            rb2D.velocity = closestKunai.GetComponent<Rigidbody2D>().velocity * kunaiTpSpeed;

            OnKunaiDestroyed();
        }
    }

    public void OnKunaiDestroyed()
    {
        kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("unlockKunai"))
        {
            enabled = true;
            Destroy(collision.gameObject);
        }
    }
}
