using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSTile : STile
{
    
    public override Vector3 calculatePosition(int x, int y) 
    {
        return new Vector3(x * STILE_WIDTH, y/2 * ((MountainGrid) SGrid.Current).layerOffset + y % 2 * STILE_WIDTH);
    }

    public override Vector3 calculateMovingPosition(float x, float y) 
    {
        Vector3 newPos = STILE_WIDTH * new Vector3(x, y);

        if(y >= 2)
            newPos += new Vector3(0, ((MountainGrid)SGrid.Current).layerOffset - 2 * STILE_WIDTH);
        return newPos;
    }
}
