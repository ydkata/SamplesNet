using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication2.Service
{
    /// <summary>
    ///  Sample Interface
    /// </summary>
    public interface ISampleService
    {

    }

    /// <summary>
    /// Sample Service
    /// </summary>
    public class SampleService : ISampleService, IDisposable
    {
        private readonly ISampleRepository repository;

        /// <summary>
        /// Constractor
        /// </summary>
        public SampleService(ISampleRepository repository)
        {
            Debug.WriteLine("Log# SampleService instance was created.");
            this.repository = repository;
        }

        public void Dispose()
        {
            Debug.WriteLine("Log# SampleService instance was Disposed.");
        }
    }
}