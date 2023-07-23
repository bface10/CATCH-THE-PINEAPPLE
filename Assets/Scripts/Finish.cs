using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("Level Selesai! Melanjutkan ke level berikutnya...");

        // Mendapatkan indeks level saat ini
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        // Jika level saat ini adalah level terakhir (level 3), kembali ke menu atau lakukan tindakan lainnya.
        if (currentLevelIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Selamat, Anda telah menyelesaikan semua level!");
            // Di sini Anda bisa menambahkan tindakan khusus setelah menyelesaikan semua level, misalnya kembali ke menu utama.
            // SceneManager.LoadScene("NamaMenuUtama"); // Contoh untuk kembali ke menu utama.
        }
        else
        {
            // Jika bukan level terakhir, pindah ke level berikutnya.
            SceneManager.LoadScene(currentLevelIndex + 1);
        }
    }
}
