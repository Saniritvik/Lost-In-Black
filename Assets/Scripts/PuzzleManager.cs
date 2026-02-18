using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public UnityEvent Action;
    public UnityEvent DiamondAction;
    public GameObject UIManger;
    public GameObject CircleInput;
    public GameObject HexagonInput;
    public GameObject SquareInput;
    public GameObject TriangleInput;
    public GameObject DiamondInput;
    public Sprite CircleFilled;
    public Sprite HexagonFilled;
    public Sprite SquareFilled;
    public Sprite TriangleFilled;
    public Sprite DiamondFilled;
    public bool WeightSolved;
    public bool Used;
    private bool DiamondUsed;
    private bool IsCircleFilled;
    private bool IsHexagonFilled;
    private bool IsSquareFilled;
    private bool IsTriangleFilled;
    private bool IsDiamondFilled;
    private SpriteRenderer CircleSprite;
    private SpriteRenderer HexagonSprite;
    private SpriteRenderer SquareSprite;
    private SpriteRenderer TriangleSprite;
    private SpriteRenderer DiamondSprite;
    private PlayerManager PlayerManagerer;





    // Start is called before the first frame update
    void Start()
    {
        PlayerManagerer = UIManger.GetComponent<PlayerManager>();
        CircleSprite = CircleInput.GetComponent<SpriteRenderer>();
        HexagonSprite = HexagonInput.GetComponent<SpriteRenderer>();
        SquareSprite = SquareInput.GetComponent<SpriteRenderer>();
        TriangleSprite = TriangleInput.GetComponent<SpriteRenderer>();
        DiamondSprite = DiamondInput.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsCircleFilled && IsHexagonFilled && IsSquareFilled && IsTriangleFilled && !Used)
        {
            Action.Invoke();
            Used = true;
        }
        if (IsDiamondFilled && !DiamondUsed) 
        { 
            DiamondUsed = true;
            DiamondAction.Invoke();
        }
    }
    public void PutInCircle() 
    {
        if (PlayerManagerer.HasCircle)
        {
            CircleSprite.sprite = CircleFilled;
            IsCircleFilled = true;
            PlayerManagerer.CircleUse();
        }
    }
    public void PutInHexagon()
    {
        if (PlayerManagerer.HasHexagon)
        {
            HexagonSprite.sprite = HexagonFilled;
            IsHexagonFilled = true;
            PlayerManagerer.HexagonUse();
        }
    }
    public void PutInSquare()
    {
        if (PlayerManagerer.HasSquare)
        {
            SquareSprite.sprite = SquareFilled;
            IsSquareFilled = true;
            PlayerManagerer.SquareUse();
        }
    }
    public void PutInTriangle()
    {
        if (PlayerManagerer.HasTriangle)
        {
            TriangleSprite.sprite = TriangleFilled;
            IsTriangleFilled = true;
            PlayerManagerer.TriangleUse();
        }
    }
    public void PutInDiamond() 
    {
        if (PlayerManagerer.HasDiamond)
        {
            DiamondSprite.sprite = DiamondFilled;
            IsDiamondFilled = true;
            PlayerManagerer.DiamondUse();
        }
    }
}
