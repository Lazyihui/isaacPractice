using UnityEngine;
using UnityEngine.UI;

public class Panel_BossedHeart : MonoBehaviour {

    [SerializeField] Image imgBg;
    [SerializeField] Image imgBar;

    public void Ctor() { }

    public void SetHp(float hp , float maxhp){
        if(maxhp == 0){
            imgBg.fillAmount = 0;
            imgBar.fillAmount = 0;
            return;
        }
        imgBar.fillAmount = hp / maxhp;
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }

}