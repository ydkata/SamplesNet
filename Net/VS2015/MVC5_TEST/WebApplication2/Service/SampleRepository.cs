using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication2.Service
{
    /// <summary>
    /// Repository用のIF
    /// </summary>
    public interface ISampleRepository
    {
    }

    public class SampleRepository : ISampleRepository, IDisposable
    {
        /// <summary>
        /// Constractor
        /// </summary>
        public SampleRepository()
        {
            Debug.WriteLine("Log# SampleRepository instance was created.");
        }

        public void Dispose()
        {
            Debug.WriteLine("Log# SampleRepository instance was Disposed.");
        }
    }
}