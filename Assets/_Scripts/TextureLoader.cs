using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextureLoader : MonoBehaviour
{

    [SerializeField]private Sprite[] emptyTextures;
    [SerializeField]private Sprite mineTexture;
    private IEnumerator WCoroutine;
    private IEnumerator LCoroutine;

    public bool mine;

    private void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        mine = Random.value < 0.1;
        Grid.tiles[x, y] = this;
        WCoroutine = Winning(3f);
        LCoroutine = Losing(3f);
    }

    public void LoadTextures(int index)
    {
            if (mine)
                GetComponent<SpriteRenderer>().sprite = mineTexture;
            else
                GetComponent<SpriteRenderer>().sprite = emptyTextures[index];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "tile";
    }

    private void OnMouseUpAsButton()
    {
        if (mine)
        {
            Grid.uncoverMines();
            StartCoroutine(LCoroutine);
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int) transform.position.y;
            LoadTextures(Grid.neighbourMines(x,y));

            Grid.FFuncover(x,y, new bool[Grid.width,Grid.height]);

            if (Grid.isFinished())
                StartCoroutine(WCoroutine);
        }
    }

    private IEnumerator Winning(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }
    private IEnumerator Losing(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(3);
    }
}
    