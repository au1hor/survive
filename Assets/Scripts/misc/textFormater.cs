using UnityEngine;

public static class textFormater
{
    public static string FormaterNumber(double value)
    {
       return value switch
        {   
            >= 1_000_000_000 => $"{value/1_000_000_000f:0.#}B",
            >= 1_000_000 => $"{value/1_000_000f:0.#}KK",
            >= 1000 => $"{value/1_000f:0.#}K",
            _ => $"{value.ToString("0.#")}"
        };
      
    }
}

