using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

public class Parser
{
    public PointF coordinates;
    public List<Shape> shapes = new List<Shape>();

	public List<Shape> ParseShapes(string Filename)
	{
		// Load xml documents
        XmlDocument doc = new XmlDocument();
		doc.Load(Filename);

        // Parse all shapes	    
		foreach(XmlNode shape in doc.SelectNodes("/shapes/*"))
		{
            int width, height;
            GetCoordinates(shape);

            if (shape.Name == "rectangle")
            {
                width = int.Parse(shape.Attributes["width"].Value);
                height = int.Parse(shape.Attributes["height"].Value);
                shapes.Add(new Rectangle((int)coordinates.X, (int)coordinates.Y, width, height));
            }
            
            if (shape.Name == "circle")
            {
                int size = int.Parse(shape.Attributes["size"].Value);
                shapes.Add(new Circle((int)coordinates.X, (int)coordinates.Y, size));
            }

            if (shape.Name == "star")
            {
                width = int.Parse(shape.Attributes["width"].Value);
                height = int.Parse(shape.Attributes["height"].Value);
                shapes.Add(new Star((int)coordinates.X, (int)coordinates.Y, width, height));
            }
            
		}
		return shapes;
    }

    public PointF GetCoordinates(XmlNode shape)
    {
        float x, y;
        x = int.Parse(shape.Attributes["x"].Value);
        y = int.Parse(shape.Attributes["y"].Value);
        coordinates.X = x;
        coordinates.Y = y;
        return coordinates;
    }
}