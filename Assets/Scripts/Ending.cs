using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public TimeText timeText;

    private void GuardarDatos()
    {
        int tiempo = 0;

        if (timeText != null)
        {
            tiempo = timeText.currentTime;
        }

        PlayerPrefs.SetInt("LastTime", tiempo);

        int mejorTiempo = PlayerPrefs.GetInt("BestTime", 999999);

        if (tiempo < mejorTiempo)
        {
            PlayerPrefs.SetInt("BestTime", tiempo);
        }

        PlayerPrefs.Save();
    }


    private void CargarFinal()
    {
        GuardarDatos();
        SceneManager.LoadScene("Ending");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
            CargarFinal();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
            CargarFinal();
    }
}
