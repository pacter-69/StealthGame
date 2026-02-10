using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public TimeText timeText;
    public int dieForEnemies = 0;
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
        {
            Debug.Log("Finish reached");
            CargarFinal();
        }
            
        if (collision.collider.CompareTag("Enemy"))
        {
            dieForEnemies = 1;
            PlayerPrefs.SetInt("DieForEnemies", dieForEnemies);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish")) { 
            Debug.Log("Finish reached");
            CargarFinal();
        }
        if (other.CompareTag("Enemy"))
        {
            dieForEnemies = 1;
            PlayerPrefs.SetInt("DieForEnemies", dieForEnemies);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("BestTime");
        PlayerPrefs.DeleteKey("LastTime");
        PlayerPrefs.Save();
    }
}
