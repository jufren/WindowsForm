<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoStreamingTestPage.aspx.cs" Inherits="ContosoUniversity.VideoStreamingTestPage" %>
<%@ Register TagPrefix="web" Namespace="ContosoUniversity" Assembly= "ContosoUniversity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script type="text/javascript" src="/Scripts/jquery-1.10.2.js"></script>
	<script type="text/javascript" src="/Scripts/jquery.signalR-2.4.0.js"></script>
<body>
    <form id="form1" runat="server">
        <div>
            
            <web:VideoStreaming runat="server" id="video" clientidmode="Static" width="300px" height="300px" interval="100" source="True" scalingmode="TargetSize" streamingmode="Target" targetclientid="received" onstreamed="onStreamed" style="border: solid 1px black" />
            <canvas id="received" width="300" height="300" style="border: solid 1px black"></canvas>
        </div>
    </form>
</body>

    <script language="Javascript">
        function onStreamed(imageUrl, imageWidth, imageHeight)
             {
                     //for StreamingMode="Event", draw an image on an existing canvas
                     //the onload event is for cross-browser compatibility
                     //in this example, we are using the canvas width and height
                     var canvas = document.getElementById('received');
                     var ctx = canvas.getContext('2d');
                     var img = new Image();
                     img.src = imageUrl;
                     img.onload = function()
                         {
                                 ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
                             }
        }
        function startStreaming()
                 {
                document.getElementById('video').startStream();
                }
              
                 function stopStreaming()
                     {
                             document.getElementById('video').stopStream();
}
    </script>
    <input type="button" value="Start Streaming" onclick="startStreaming()"/>
    <input type="button" value="Stop Streaming" onclick="stopStreaming()" />
</html>
