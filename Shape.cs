using System;
using System.Drawing;

public abstract class Shape
{
    protected int x, y;

    protected Shape()
	{
	}

    public abstract void Draw(Graphics Canvas);
	
}