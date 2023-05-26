using UnityEngine;

public class CountManagerScript : MonoBehaviour
{
    public int countForWin;
    public int level = 1;

    #region Singleton
    public static CountManagerScript instance;//singleton

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this); //ayn� bu sahneyi devam ettiriyor ikinci sahnede gelmesi gerekenler varsa bulamaz
    }
    #endregion

    public bool EndCount() //bool de�er d�nd�r�yor //
    {
        if(countForWin == LevelManager.instance.count)
        {
            return true;
        }
        return false;
    }
}
