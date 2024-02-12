using UnityEngine;
using UnityEngine.SceneManagement;

public class ElegirDificultad : MonoBehaviour
{
    Monocroma mon3;
    Beatlvl3 Beat3;
    VidaPers3 vidaPers3;
    Monocroma1 mon1;
    Beatlvl1 Beat1;
    VidaPers1 vidaPers1;
    MovJugador lulu;
    SpawnKunai kunai;
    public GameObject Player;
    public GameObject Game;
    public GameObject CameraDes;
    // Start is called before the first frame update
    void Start()
    {
        mon3 = Player.GetComponent<Monocroma>();
        Beat3 = Player.GetComponent<Beatlvl3>();
        vidaPers3 = Player.GetComponent<VidaPers3>();        
        mon1 = Player.GetComponent<Monocroma1>();
        Beat1 = Player.GetComponent<Beatlvl1>();
        vidaPers1 = Player.GetComponent<VidaPers1>();
        lulu = Player.GetComponent<MovJugador>();
        kunai = Player.GetComponent<SpawnKunai>();
        Game.SetActive(false);
    }

    // Update is called once per frame
    public void Easy()
    {
        Activarjuego();
        Beat3.enabled = true;
        mon3.enabled = true;
        vidaPers3.enabled = true;
        Beat1.enabled = false;
        mon1.enabled = false;
        vidaPers1.enabled = false;
        Destroy(gameObject);
    }

    public void Hard()
    {
        Activarjuego();
        Beat1.enabled = true;
        mon1.enabled = true;
        vidaPers1.enabled = true;
        Beat3.enabled = false;
        mon3.enabled = false;
        vidaPers3.enabled = false;
        Destroy(gameObject);
    }
    void Activarjuego()
    {
        Game.SetActive(true);
        Destroy(CameraDes);
        lulu.enabled = true;
        kunai.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
