using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OpenGLHelper
{
    // Use Example:
    // OpenGLHelper.DrawRectangle(new Vector2Int(0, 0), 10, 10, Color.blue);
    // OpenGLHelper.DrawRectangle(new Vector2Int(10, 0), 10, 10, Color.blue);
    public static void DrawRectangle(Vector2Int startingPoint, float width, float height)
    {
        GL.Begin(GL.QUADS);
        GL.Color(Color.black);
        GL.Vertex3(startingPoint.x, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y + height, 0);
        GL.Vertex3(startingPoint.x, startingPoint.y + height, 0);
        GL.End();
    }

    public static void DrawRectangle(Vector2Int startingPoint, float width, float height, Color color)
    {
        GL.Begin(GL.QUADS);
        GL.Color(color);
        GL.Vertex3(startingPoint.x, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y + height, 0);
        GL.Vertex3(startingPoint.x, startingPoint.y + height, 0);
        GL.End();
    }
}
