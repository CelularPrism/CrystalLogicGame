using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static PlayerStatic;

public class IventManager : MonoBehaviour
{
    List<IventInterface> iventInterfaces = new List<IventInterface>();/* = new List<IventInterface> {
        new DeadMenTellNoLies(), new EasyMetal(), new EasyProfit(),
        new FirstComeFirstServe(), new FreeCheese(), new NightmareFuel(),
        new Silhouettes(), new CorneredBeast(), new DeepLake(),
        new MysteriousContainer(), new NoFarmNoHoul(), new RaysKindness(),
        new VengefulPirate(), new Vultures(), new WoundedGasGanger()
    }; */
    // Надо отредактировать MysteriousContainer, он сложен в реализации
    private SceneController controller;

    private Text head;
    private Text text;
    
    private Text textA;
    private Text textB;

    private Image imgRes;
    private Text textCount; // Change resources
    
    private Transform OkBtn;
    private Transform FightField;

    private IventInterface ivent;
    private AudioSource audioSourceSound;
    private AudioSource audioSourceMusic;

    private void GenerateParameters()
    {
        controller = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        head = transform.GetChild(0).GetComponent<Text>();
        text = transform.GetChild(2).GetComponent<Text>();
        textA = transform.GetChild(3).GetChild(0).GetComponent<Text>();
        textB = transform.GetChild(4).GetChild(0).GetComponent<Text>();
        imgRes = transform.GetChild(5).GetChild(0).GetComponent<Image>();
        textCount = transform.GetChild(5).GetChild(2).GetComponent<Text>();
        OkBtn = transform.GetChild(6);

        FightField = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(3);

        if (PlayerStatic.listIvents.Count() == 0)
        {

            var list = from t in Assembly.GetExecutingAssembly().GetTypes()
                       where t.GetInterfaces().Contains(typeof(IventInterface))
                                && t.GetConstructor(System.Type.EmptyTypes) != null
                       select System.Activator.CreateInstance(t) as IventInterface;

            foreach (IventInterface i in list.ToList())
                if (i.GetType().Name.Substring(i.GetType().Name.Length - 4) != "Link")
                    iventInterfaces.Add(i);

            PlayerStatic.listIvents = iventInterfaces;
        }
        else
        {
            iventInterfaces = PlayerStatic.listIvents;
        }

        GameObject GOSound = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).gameObject;
        GameObject GOMusic = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(1).gameObject;

        audioSourceSound = GOSound.GetComponent<AudioSource>();
        audioSourceMusic = GOMusic.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (iventInterfaces.Count() == 0 || controller == null)
            GenerateParameters();
        int num = Random.Range(0, iventInterfaces.Count - 1);

        ivent = iventInterfaces[num];

        ivent.SetIventManager(this);
        ivent.StartIvent();

        head.text = ivent.dataIvent.TextHeader;
        text.text = ivent.dataIvent.Text;
        textA.text = ivent.dataIvent.VarA;
        textB.text = ivent.dataIvent.VarB;

        audioSourceMusic.volume = 0.3f;
        audioSourceSound.clip = ivent.dataIvent.audioText;
        audioSourceSound.Play();

        textA.transform.parent.gameObject.SetActive(true);
        textB.transform.parent.gameObject.SetActive(true);

        imgRes.gameObject.SetActive(false);
        textCount.gameObject.SetActive(false);
        OkBtn.gameObject.SetActive(false);
    }

    public void Final(string finalText)
    {
        iventInterfaces.Remove(ivent);
        PlayerStatic.listIvents = iventInterfaces;
        text.text = finalText;

        textA.transform.parent.gameObject.SetActive(false);
        textB.transform.parent.gameObject.SetActive(false);
        OkBtn.gameObject.SetActive(true);
    }

    public void Battle()
    {
        FightField.GetComponent<FightUIManager>().card = new Card();
        Card card = FightField.GetComponent<FightUIManager>().card;
        DataCard[] dataCards = Resources.LoadAll<DataCard>("ScriptableObjects/Cards/Enemy");
        int num = Random.Range(0, dataCards.Length - 1);
        DataCard dataCard = dataCards[num];
        int damage = Random.Range(dataCard.minDamage, dataCard.maxDamage);
        int health = Random.Range(dataCard.minHealth, dataCard.maxHealth);

        card.dataCard = dataCard;
        card.Health = health;
        card.Damage = damage;

        FightField.gameObject.SetActive(true);
        Transform sceneController = GameObject.FindGameObjectWithTag("SceneController").transform;
        sceneController.GetChild(0).gameObject.SetActive(false);
        sceneController.GetChild(1).gameObject.SetActive(false);
    }

    public void SetIvent(IventInterface iventInterface)
    {
        iventInterfaces.Remove(ivent);
        ivent = iventInterface;
        ivent.SetIventManager(this);
        ivent.StartIvent();

        text.text = ivent.dataIvent.Text;
        textA.text = ivent.dataIvent.TextA;
        textB.text = ivent.dataIvent.TextB;
    }

    public void SetImage(Sprite image, string count)
    {
        imgRes.gameObject.SetActive(true);
        textCount.gameObject.SetActive(true);

        imgRes.sprite = image;
        imgRes.SetNativeSize();
        textCount.text = count;
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        audioSourceSound.clip = audioClip;
        audioSourceSound.Play();
    }

    public void ChangeHealth(int health)
    {
        controller.health += health;
    }

    public void ChangeIron(int iron)
    {
        controller.iron += iron;
    }

    public void ChangeFuel(int fuel)
    {
        controller.fuel += fuel;
    }

    public void DeleteLoot(string name, int count)
    {
        if (controller.lootList[name] == count)
            controller.lootList.Remove(name);
        else
            controller.lootList[name] -= count;
    }

    public void InsertLoot(string name, int count)
    {
        if (controller.lootList.ContainsKey(name))
            controller.lootList[name] += count;
        else
            controller.lootList[name] = count;
    }

    public void VarA()
    {
        ivent.VarA();
    }

    public void VarB()
    {
        ivent.VarB();
    }

    public void ReturnMusicSettings()
    {
        audioSourceSound.Stop();
        audioSourceMusic.volume = 1f;
    }

    public bool CheckRes(string name, int count)
    {
        if (controller.lootList.ContainsKey(name))
            return controller.lootList[name] == count;
        else
            return false;
    }

    public float GetIron()
    {
        return controller.iron;
    }
}
