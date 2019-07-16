using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour
{

    private LocationService locationServer;
    private LocationServiceStatus locationServerStatus;
    private LocationInfo locationInfo;

    private bool isCould;  //是否开启定位服务，即开启GPS定位
    private float altitude; 
    private float horizontalAccuracy; 
    private float verticalAccuracy; 
    private static float latitude;       
    private static float longitude;      
    private double timestamp;    

    // Use this for initialization  
    void Start()
    {
        locationServer = Input.location;
        isCould = locationServer.isEnabledByUser; //用户是否可以设置定位服务      
        locationServerStatus = locationServer.status; //返回设备服务状态
        //参数1 服务所需的精度，以米为单位，参数2 最小更新距离
        locationServer.Start(1, 1);//开始位置更新服务，最后的位置坐标
        //locationServer.Stop();//停止位置服务更新
    }

    void Update()
    {
        //调用该方法之前确保调用了 Input.location.Start()
        //设备最后检测的位置
        locationInfo = locationServer.lastData;
        altitude = locationInfo.altitude;
        horizontalAccuracy = locationInfo.horizontalAccuracy; 
        verticalAccuracy = locationInfo.verticalAccuracy; 
        latitude = locationInfo.latitude; 
        longitude = locationInfo.longitude;
        timestamp = locationInfo.timestamp;
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 15;

        GUI.Label(new Rect(550, 0, 500, 80), "isCould : " + isCould);
        GUI.Label(new Rect(550, 25, 800, 80), "locationInfo : " + locationInfo);
        GUI.Label(new Rect(550, 50, 500, 80), "Altitude     :   " + altitude);
        GUI.Label(new Rect(550, 75, 500, 80), "HorizontalAccuracy :   " + horizontalAccuracy);
        GUI.Label(new Rect(550, 100, 500, 80), "VerticalAccuracy :   " + verticalAccuracy);
        GUI.Label(new Rect(550, 125, 500, 80), "Latitude     :   " + latitude);
        GUI.Label(new Rect(550, 150, 500, 80), "Longitud     :   " + longitude);
        GUI.Label(new Rect(550, 175, 500, 80), "Timestamp    :   " + timestamp);
    }

    public static void sendLocation()
    {
        setLatitude();
        setLongitude();
        GoogleApi.setLatitude(latitude);
        GoogleApi.setLongitude(longitude);
        Chat.sendLocation();
    }

    public static void setLatitude()
    {
        Chat.setLatitude(latitude);
    }

    public static void setLongitude()
    {
        Chat.setLongitude(longitude);
    }
}
