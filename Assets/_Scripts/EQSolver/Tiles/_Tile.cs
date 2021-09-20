using Assets._Scripts.Enums;
using Assets._Scripts.EQSolver;
using UnityEngine;

public class _Tile : MonoBehaviour
{

    public FillStatus Status { get; protected set; }
    public FieldType FieldType { get; set; }

    public void ChangeStatus()
    {
        if (Status == FillStatus.EMPTY)
        {
            Status = FillStatus.FULL;
        }
        else Status = FillStatus.EMPTY;
    }

    public virtual bool CheckFullness() { return false; }

    public virtual void AdaptByFieldType() { }

}
