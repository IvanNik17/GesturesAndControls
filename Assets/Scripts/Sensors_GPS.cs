using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Android;

public class Sensors_GPS : MonoBehaviour
{
    public TextMeshProUGUI gpsText;

    void Start()
    {
    #if PLATFORM_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
            }
    #endif

        StartCoroutine(StartLocationService());
    }

    IEnumerator StartLocationService()
    {
        // Check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            gpsText.text = "Location not enabled on device.";
            yield break;
        }

        // Start service
        Input.location.Start(1f, 0.1f); // desiredAccuracy, updateDistance

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            gpsText.text = "Timed out initializing GPS.";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            gpsText.text = "Unable to determine device location.";
            yield break;
        }

        // Service initialized, start updating
        gpsText.text = "GPS Ready!";
    }

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            var data = Input.location.lastData;
            gpsText.text = $"Lat: {data.latitude:F6}\nLon: {data.longitude:F6}\nAlt: {data.altitude:F1} m\nAccuracy: {data.horizontalAccuracy:F1} m\nTimestamp: {data.timestamp}";
        }
    }

    void OnDisable()
    {
        Input.location.Stop();
    }
}
