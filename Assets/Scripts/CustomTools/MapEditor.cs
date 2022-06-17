using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public partial class MapEditor : EditorWindow
{
    private Material material;

    [MenuItem("Tools/Map Editor")]
    public static void StartEditor()
    {
        MapEditor mapEditorWindow = EditorWindow.GetWindow<MapEditor>("Map Editor", true);
        mapEditorWindow.Show();
    }

    void OnEnable()
    {
        // Find the "Hidden/Internal-Colored" shader, and cache it for use.
        material = new Material(Shader.Find("Hidden/Internal-Colored"));
    }

    void OnGUI()
    {
        // Begin to draw a horizontal layout, using the helpBox EditorStyle
        GUILayout.BeginHorizontal(EditorStyles.helpBox);

        // Reserve GUI space with a width from 10 to 10000, and a fixed height of 200, and 
        // cache it as a rectangle.
        Rect layoutRectangle = GUILayoutUtility.GetRect(10, 10000, 200, 200);

        if (Event.current.type == EventType.Repaint)
        {
            // If we are currently in the Repaint event, begin to draw a clip of the size of 
            // previously reserved rectangle, and push the current matrix for drawing.
            GUI.BeginClip(layoutRectangle);
            GL.PushMatrix();

            // Clear the current render buffer, setting a new background colour, and set our
            // material for rendering.
            GL.Clear(true, false, Color.black);
            material.SetPass(0);

            // Start drawing in OpenGL Quads, to draw the background canvas. Set the
            // colour black as the current OpenGL drawing colour, and draw a quad covering
            // the dimensions of the layoutRectangle.
            DrawRectangle(new Vector2Int(0, 0), layoutRectangle.width, layoutRectangle.height);
            DrawRectangle(new Vector2Int(0, 0), 10, 10, Color.blue);
            DrawRectangle(new Vector2Int(10, 0), 10, 10, Color.blue);
            // Start drawing in OpenGL Lines, to draw the lines of the grid.
            GL.Begin(GL.LINES);

            int count = (int)(layoutRectangle.width / 10) + 20;

            for (int i = 0; i < count; i++)
            {
                // For every line being drawn in the grid, create a colour placeholder; if the
                // current index is divisible by 5, we are at a major segment line; set this
                // colour to a dark grey. If the current index is not divisible by 5, we are
                // at a minor segment line; set this colour to a lighter grey. Set the derived
                // colour as the current OpenGL drawing colour.
                Color lineColour = (i % 5 == 0
                    ? new Color(0.5f, 0.5f, 0.5f) : new Color(0.2f, 0.2f, 0.2f));
                GL.Color(lineColour);

                // Derive a new x co-ordinate from the initial index, converting it straight
                // into line position
                float x = i * 10;

                if (x >= 0 && x < layoutRectangle.width)
                {
                    // If the current derived x position is within the bounds of the
                    // rectangle, draw another vertical line.
                    GL.Vertex3(x, 0, 0);
                    GL.Vertex3(x, layoutRectangle.height, 0);
                }

                if (i < layoutRectangle.height / 10)
                {
                    // Convert the current index value into a y position, and if it is within
                    // the bounds of the rectangle, draw another horizontal line.
                    GL.Vertex3(0, i * 10, 0);
                    GL.Vertex3(layoutRectangle.width, i * 10, 0);
                }
            }

            // End lines drawing.
            GL.End();

            // Pop the current matrix for rendering, and end the drawing clip.
            GL.PopMatrix();
            GUI.EndClip();
        }

        // End our horizontal 
        GUILayout.EndHorizontal();
    }

    private void DrawRectangle(Vector2Int startingPoint, float width, float height)
    {
        GL.Begin(GL.QUADS);
        GL.Color(Color.black);
        GL.Vertex3(startingPoint.x, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y, 0);
        GL.Vertex3(startingPoint.x + width, startingPoint.y + height, 0);
        GL.Vertex3(startingPoint.x, startingPoint.y + height, 0);
        GL.End();
    }

    private void DrawRectangle(Vector2Int startingPoint, float width, float height, Color color)
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
#endif
