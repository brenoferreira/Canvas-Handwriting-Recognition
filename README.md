Canvas Handwriting Recognition
==============================

Implementation of a handwriting recognition system using HTML5 canvas. The actual recognition happens on the server. The input data is sent to the server through a POST call on the client, which sends all the X-Y coordinates of the strokes formatted in JSON. On the server, it is converted to a data structure used by Windows Presentation Foundation (WPF) Ink Framework. The recognized string is sent back to the client after a sucessful analysis.

Dependencies
------------

+ ASP.NET MVC 4 Beta
+ JSON.NET
+ JQuery
+ IACore.dll
+ IALoader.dll
+ IAWinFX.dll