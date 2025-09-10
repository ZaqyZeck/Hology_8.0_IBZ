using UnityEngine;

public class PlacePlantButton : ButtonScript
{
    public int _plantId;
    private LandLot _landLot;
    private RotationControl _rotationControl;

    [SerializeField] private GameObject kubisTutorial;

    private void Awake()
    {
        _landLot = gameObject.GetComponentInParent<LandLot>();
        _rotationControl = FindAnyObjectByType<RotationControl>();
        //Debug.Log("bitu");
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_rotationControl._isRotating)
        {
            _landLot.PlacePlantBy(_plantId);
            if (!alurTutorial.alur[0]) alurTutorial.alur[0] = true;
            Debug.Log("terpencet");
        }
    }

    private void OnEnable()
    {
        if (!alurTutorial.alur[0])
        {
            if (kubisTutorial == null) return;
            kubisTutorial.SetActive(true);
        }
        else
        {
            if (kubisTutorial == null) return;
            kubisTutorial.SetActive(false);
        }
        
    }
}
