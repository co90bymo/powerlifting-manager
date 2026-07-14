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


        AthleteCardUI athleteCard = eventData.pointerDrag.GetComponent<AthleteCardUI>();

        if (athleteCard != null)
        {
            athleteCard.Athlete.TrainingGroup = trainingGroup;
            athleteCard.RefreshColor();

            Debug.Log(
                $"{athleteCard.Athlete.Name} assigned to {trainingGroup}"
            );
        }
    }
}