using System.Collections.Generic;
using UnityEngine;

public class SpawnKunai : MonoBehaviour
{
    [SerializeField] private float KunaiVelocity;
    public GameObject KunaiPrefab;
    public GameObject BlackHolePrefab; 
    public GameObject WhiteHolePrefab; 
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
    KunaiConstraint kc;
    public float raycastSize = 0.5f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        kc = GetComponent<KunaiConstraint>();
        sk = GetComponent<SpawnKunai>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        kunaiCount = SceneControl.kunaiMax;
        kunaiCount = 3;
        nmdk = kunaiText.GetComponent<NumeroDeKunais>();
        if (!UpgradeMenu.kunaiOwnedd)
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
        
        if (Input.GetKeyDown(KeyCode.S) && UpgradeMenu.tpOwnedd)
        {
            BringKunaiBack();
            Debug.Log("1");
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
        animator.SetBool("IsThrowingKunai", true);
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

    public void BringKunaiBack()
    {
        kunaiCount++;

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
        Destroy(closestKunai);
        /* GameObject whiteHole = Instantiate(WhiteHolePrefab, PlayerLocation.transform.position, Quaternion.identity);
         Destroy(whiteHole, 0.35f);
         GameObject blackHole = Instantiate(BlackHolePrefab, closestKunai.transform.position, Quaternion.identity);
         Destroy(blackHole, 0.35f);*/
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
                }
            }
        }

        if (closestKunai != null)
        {
            Transform tpSpotChild = closestKunai.transform.Find("TPSpot");

            if (tpSpotChild != null)
            {
                GameObject blackHole = Instantiate(BlackHolePrefab, PlayerLocation.transform.position, Quaternion.identity);
                Destroy(blackHole, 0.35f);
                GameObject whiteHole = Instantiate(WhiteHolePrefab, tpSpotChild.position, Quaternion.identity);
                Destroy(whiteHole, 0.35f);

                Physics2D.RaycastAll(tpSpotChild.transform.position, Vector2.down * raycastSize);
                PlayerLocation.transform.position = tpSpotChild.position;

                Destroy(closestKunai);
                kunaiList.Remove(closestKunai);
                OnKunaiDestroyed();
            }
            else
            {
                Debug.LogWarning("No se encontr� el empty object hijo 'KunaiTpSpot' del kunai m�s cercano.");
            }
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
