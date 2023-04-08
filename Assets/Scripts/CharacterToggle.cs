using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterToggle : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool _startRender = false;
    [SerializeField] private RenderTool _renderTool;

    [Header("---Toc")]
    public List<GameObject> Trait1 = new List<GameObject>();
    [Header("---Gang Tay")]
    public List<GameObject> Trait2 = new List<GameObject>();
    [Header("---Kinh")]
    public List<GameObject> Trait3 = new List<GameObject>();
    [Header("---Vu Khi")]
    public List<GameObject> Trait4 = new List<GameObject>();
    [Header("---Tu chi/Canh vay")]
    public List<GameObject> Trait5 = new List<GameObject>();
    [Header("---Mau da")]
    public List<GameObject> Trait6 = new List<GameObject>();


    public List<List<GameObject>> AllTrait = new List<List<GameObject>>();

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
        AllTrait = new List<List<GameObject>> { Trait1, Trait2, Trait3, Trait4, Trait5, Trait6 };
        _anim.Play("Idle");

    }


    // Update is called once per frame
    void Update()
    {
        if (AutoRenderVideo.CanRender && !_startRender)
        {
            EndAnimationListener();
            _startRender = true;
        }
    }

    void OnEnable()
    {
        EndAnimationTrigger.EndAnimationEvent += EndAnimationListener;
        // EndAnimationTrigger.PlayAnimationEvent += PlayAnimationListener;
    }

    void OnDisable()
    {
        EndAnimationTrigger.EndAnimationEvent -= EndAnimationListener;
        // EndAnimationTrigger.PlayAnimationEvent -= PlayAnimationListener;
    }

    private void EndAnimationListener()
    {
        string[] posT = AutoRenderVideo.Data[AutoRenderVideo.NumIndex].Split(",");
        Debug.Log(posT.Length);
        AllTrait.ForEach(trait =>
        {
            for (int j = 0; j < trait.Count; j++)
            {
                if (trait[j] != null)
                {
                    trait[j].SetActive(false);
                }

            }
        });
        for (int i = 0; i < posT.Length; i++)
        {
            float targetFactor = float.Parse(posT[i]) / 10;
            if(targetFactor.ToString().Length ==1) continue;
            int targetActive = int.Parse(targetFactor.ToString().Split(".")[1]);
            AllTrait[i][targetActive - 1].SetActive(true);
        }
        // RenderTool.nftsName[_charIndex] = AutoRenderVideo.Data[targetIndex];
        string nameId = string.Join("", posT);
        _renderTool.NftName = "05" + nameId;
    }
    
    public void PlayAnimationListener()
    {
        _anim.Play("Idle", 0, 0.0f);
    }
}
