using UnityEngine;

public static class WaveMath {
    
    // Secant Sec(X) = 1 / Cos(X) 
    // Cosecant Cosec(X) = 1 / Sin(X) 
    // Cotangent Cotan(X) = 1 / Tan(X) 
    // Inverse Sine Arcsin(X) = Atn(X / Sqr(-X * X + 1)) 
    // Inverse Cosine Arccos(X) = Atn(-X / Sqr(-X * X + 1)) + 2 * Atn(1) 
    // Inverse Secant Arcsec(X) = 2 * Atn(1) - Atn(Sgn(X) / Sqr(X * X - 1)) 
    // Inverse Cosecant Arccosec(X) = Atn(Sgn(X) / Sqr(X * X - 1)) 
    // Inverse Cotangent Arccotan(X) = 2 * Atn(1) - Atn(X) 
    // Hyperbolic Sine HSin(X) = (Exp(X) - Exp(-X)) / 2 
    // Hyperbolic Cosine HCos(X) = (Exp(X) + Exp(-X)) / 2 
    // Hyperbolic Tangent HTan(X) = (Exp(X) - Exp(-X)) / (Exp(X) + Exp(-X)) 
    // Hyperbolic Secant HSec(X) = 2 / (Exp(X) + Exp(-X)) 
    // Hyperbolic Cosecant HCosec(X) = 2 / (Exp(X) - Exp(-X)) 
    // Hyperbolic Cotangent HCotan(X) = (Exp(X) + Exp(-X)) / (Exp(X) - Exp(-X)) 
    // Inverse Hyperbolic Sine HArcsin(X) = Log(X + Sqr(X * X + 1)) 
    // Inverse Hyperbolic Cosine HArccos(X) = Log(X + Sqr(X * X - 1)) 
    // Inverse Hyperbolic Tangent HArctan(X) = Log((1 + X) / (1 - X)) / 2 
    // Inverse Hyperbolic Secant HArcsec(X) = Log((Sqr(-X * X + 1) + 1) / X) 
    // Inverse Hyperbolic Cosecant HArccosec(X) = Log((Sgn(X) * Sqr(X * X + 1) + 1) / X) 
    // Inverse Hyperbolic Cotangent HArccotan(X) = Log((X + 1) / (X - 1)) / 2 
    // Logarithm to base N LogN(X) = Log(X) / Log(N)

    public static float Sin(float position) {
        return Mathf.Sin(position * 2 * Mathf.PI);
    }
    
    public static float Cos(float position) {
        return Mathf.Cos(position * 2 * Mathf.PI);
    }

    public static float Tan(float position) {
        return Mathf.Tan(position * 2 * Mathf.PI);
    }

    public static float Saw(float position) {
        return position * 2 - 1;
    }

    public static float Triangle(float position) {
        return 1-Mathf.Abs(position - 0.5f) * 4;
    }
    
    public static float ScreechNoise(float position) {
        return 2 * (RRandom.Percent((long) (position * 100000)) - 0.5f);
    }

    public static float TimeNoise(float position) {
        return 2 * RRandom.Percent(RRandom.Random()) - 1f;
    }

}
