using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcSceneKDE 
{
    // Output values type
    enum OutputValues 
    {
        Raw,
        Scaled
    };

    // Kernel shape type
    public enum KernelShape
    {
        Gaussian,
        Quartic,
        Uniform,
        Triweight,
        Epanechnikov
    };

    public static class AlgorithmKDE3D
    {
        public static double calculateKernelValue(double distance, double bandwidth, KernelShape shape)
        {            
            switch(shape)
            {
                case KernelShape.Epanechnikov:
                    return epanechnikovKernel(distance, bandwidth);
                case KernelShape.Gaussian:
                    return gaussianKernel(distance, bandwidth);
                case KernelShape.Quartic:
                    return quarticKernel(distance, bandwidth);
                case KernelShape.Triweight:
                    return triweightKernel(distance, bandwidth);
                case KernelShape.Uniform:
                    return uniformKernel(distance, bandwidth);
            }
            return 0;
        }

        //! Epanechnikov kernel function
        public static double epanechnikovKernel(double distance, double bandwidth)
        {
            double density = 2.0 / (Math.PI * bandwidth * bandwidth) * Math.Max(0, 1 - (distance * distance) / (bandwidth * bandwidth));
            return density;
        }

        //! Gaussian kernel function
        public static double gaussianKernel(double distance, double bandwidth)
        {
            double density = 2.0 / (Math.PI * bandwidth * bandwidth) * Math.Exp(- -(distance * distance) / (2* bandwidth * bandwidth));
            return density;
        }

        //! Quartic kernel function
        public static double quarticKernel(double distance, double bandwidth)
        {
            double density = 21.75 / (Math.PI * bandwidth * bandwidth) * Math.Pow( Math.Max(0, 1 -(distance * distance) / ( bandwidth * bandwidth)), 2.0);
            return density;            
        }

        //! Triweight kernel function
        public static double triweightKernel(double distance, double bandwidth)
        {
            double density = 4.0 / (Math.PI * bandwidth * bandwidth) * Math.Pow(Math.Max(0, 1 - (distance * distance) / (bandwidth * bandwidth)), 3.0);
            return density;    
        }

        //! Uniform kernel function
        public static double uniformKernel(double distance, double bandwidth)
        {
            double density = distance < bandwidth ? 1.0 / (Math.PI * bandwidth * bandwidth) : 0.0;
            return density;
        }
      
    }
}
