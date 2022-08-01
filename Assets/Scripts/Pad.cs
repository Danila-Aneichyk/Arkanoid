using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Unity lifecycle

    private void Update()
    {
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        mousePositionInUnits.z = 0;
        Vector3 currentPosition = transform.position;
        currentPosition.x = mousePositionInUnits.x;
        transform.position = mousePositionInUnits;
        transform.position = currentPosition;
    }
    

    #endregion


    


    #region Public methods

    public static void MoveToStartPosition()
    {
        
    }

    #endregion
}