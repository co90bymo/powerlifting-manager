using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingGroupSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform content;
    [SerializeField] private TrainingGroup trainingGroup;


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDropEvent");

        DragDrop draggedCard = eventData.pointerDrag.GetComponent<DragDrop>();

        if (draggedCard != null)
        {
            draggedCard.SetDropParent(content);
        }


        AthleteTrainingRowUI row = eventData.pointerDrag.GetComponent<AthleteTrainingRowUI>();

        if (row != null)
        {
            row.Athlete.TrainingGroup = trainingGroup;
            row.RefreshColor();

            Debug.Log(
                $"{row.Athlete.Name} assigned to {trainingGroup}"
            );
        }
    }
}