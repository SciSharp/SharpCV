using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpCV
{
    public class DisposableObject : IDisposable
    {
        protected IntPtr _handle;

        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            FreeHandle();

            _handle = IntPtr.Zero;

            disposed = true;
        }

        protected virtual void FreeHandle()
        {
            Marshal.FreeHGlobal(_handle);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}
